using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnLoad : MonoBehaviour
{
    public Transform SpawnPoint;
    void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = SpawnPoint.position;
    }
}
