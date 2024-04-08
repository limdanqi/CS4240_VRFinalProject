using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    private Vector3 respawnPosition1 = new Vector3(98.33f, 2.048678f, 131.5686f);
    private Vector3 respawnPosition2 = new Vector3(124.3336f, 2.026643f, 124.712f);

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lakearea")
        {
            Debug.Log("dropped something in lake");
            Vector3 respawnPosition = transform.position.x < 120 ? respawnPosition1 : respawnPosition2;
            transform.position = respawnPosition;
        }
    }
}