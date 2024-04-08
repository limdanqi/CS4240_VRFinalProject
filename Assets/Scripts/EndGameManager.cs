using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        if (button == null)
            button = GetComponent<Button>();

        // Add a listener to the button's onClick event
        button.onClick.AddListener(OnButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnButtonClicked()
    {
        SceneManager.LoadScene("GameOver");
        GameOverManager.GetPlayerData(
                WristTimerDisplay.getTimeElapsed(),
                CounterController.initialInvasives - CounterController.invasiveRemaining,
                AnimalController.totalAttemptedKills,
                CounterController.totalRelocateAnimals,
                CounterController.rightHabitat
                );
    }
}
