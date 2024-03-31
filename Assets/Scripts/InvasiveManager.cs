using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasiveManager : MonoBehaviour
{
    public static int invasiveRemainingCounter;

    void Start()
    {
        // Initialize the counter with the total number of invasive animals
        invasiveRemainingCounter = GameObject.FindGameObjectsWithTag("Invasive").Length;
    }

    public static void DecrementCounter()
    {
        invasiveRemainingCounter--;
        Debug.Log("Remaining invasive animals: " + invasiveRemainingCounter);
    }
}
