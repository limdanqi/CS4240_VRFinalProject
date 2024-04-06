using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private static string timeToComplete;
    private static int invasiveLeftFinal;
    private static int totalRelocateFinal;
    private static int rightHabitatFinal;

    // Start is called before the first frame update
    void Awake()
    {
        printPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void GetPlayerData(string time, int invasiveLeft, int totalRelocate, int rightHabitat)
    {
        timeToComplete = time;
        invasiveLeftFinal = invasiveLeft;
        totalRelocateFinal = totalRelocate;
        rightHabitatFinal = rightHabitat;
    }

    void printPlayerData()
    {
        Debug.Log(timeToComplete);
        Debug.Log(invasiveLeftFinal);
        Debug.Log(totalRelocateFinal);
        Debug.Log(rightHabitatFinal);
    }
}
