using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    private static float timeToComplete;
    private static int invasiveKilledFinal;
    private static int totalAttemptedKillFinal;
    private static int totalRelocateFinal;
    private static int rightHabitatFinal; 
    public TextMeshProUGUI invasiveDataUI;
    public TextMeshProUGUI relocateDataUI;
    public TextMeshProUGUI timeDataUI;

    // Start is called before the first frame update
    void Awake()
    {
        printPlayerData();
        displayPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void GetPlayerData(float time, int invasiveKilled, int totalAttemptedKills, int totalRelocate, int rightHabitat)
    {
        timeToComplete = time;
        invasiveKilledFinal = invasiveKilled;
        totalAttemptedKillFinal = totalAttemptedKills;
        totalRelocateFinal = totalRelocate;
        rightHabitatFinal = rightHabitat;
    }

    void displayPlayerData()
    {
        float wrongSpeciesKilled = ((float)(totalAttemptedKillFinal - invasiveKilledFinal)/totalAttemptedKillFinal) * 100;
        invasiveDataUI.text = string.Format("Your error rate is {0}%", (int)wrongSpeciesKilled);
        float correctRelocatePercentage = ((float)rightHabitatFinal / totalRelocateFinal) * 100;
        relocateDataUI.text = string.Format("You have relocated {0}% of animals", (int)correctRelocatePercentage);
        int minutes = Mathf.FloorToInt(timeToComplete / 60);
        int seconds = Mathf.FloorToInt(timeToComplete % 60);
        string timerString = string.Format("You took {0:00}:{1:00} mins", minutes, seconds);
        timeDataUI.text = timerString;
    }

    void printPlayerData()
    {
        Debug.Log(timeToComplete);
        Debug.Log(invasiveKilledFinal);
        Debug.Log(totalRelocateFinal);
        Debug.Log(rightHabitatFinal);
    }
}
