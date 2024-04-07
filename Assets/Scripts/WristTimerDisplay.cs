using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WristTimerDisplay : MonoBehaviour
{
    public float countdownDuration = 10f; 
    private float currentTime = 0f;
    private TextMeshProUGUI timerText;

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
                CounterController.invasiveRemaining,
                CounterController.totalRelocateAnimals,
                CounterController.rightHabitat
                );
            enabled = false;
        }
    }
}
