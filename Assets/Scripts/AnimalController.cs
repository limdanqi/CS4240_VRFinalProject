using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public static int totalAttemptedKills;
    // Start is called before the first frame update
    void Start()
    {
        totalAttemptedKills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void IncrementKillCounter()
    {
        totalAttemptedKills++;
    }

    public void OnSelectExited()
    {
        Destroy(gameObject);
    }
}
