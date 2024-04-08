using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WristTimerDisplay : MonoBehaviour
{
    public static float countdownDuration = 300f; 
    private static float currentTime = 0f;
    private TextMeshProUGUI timerText;

    private bool hasPlayedGameEndSound = false; // Flag to track if the game end sound has been played

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        if (timerText == null)
        {
            Debug.LogError("Timer script requires a Text component.");
            enabled = false;
            return;
        }
        currentTime = countdownDuration;

        // Play the game start sound when the timer starts
        TimerSoundEffects.instance.PlayGameStartSound();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;

        if (currentTime <= 0f)
        {
            timerText.text = "Time's up!";
            SceneManager.LoadScene("GameOver");
            GameOverManager.GetPlayerData(
                countdownDuration - currentTime,
                CounterController.initialInvasives - CounterController.invasiveRemaining,
                AnimalController.totalAttemptedKills,
                CounterController.totalRelocateAnimals,
                CounterController.rightHabitat
                );
            enabled = false;
        }

        // Play the game end sound when there are 5 seconds left
        if (currentTime <= 5f && !hasPlayedGameEndSound)
        {
            TimerSoundEffects.instance.PlayGameEndSound();
            hasPlayedGameEndSound = true; // Set the flag to true to ensure the sound is played only once
        }
    }

    public static float getTimeElapsed()
    {
        return countdownDuration - currentTime;
    }
}
