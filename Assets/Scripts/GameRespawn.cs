using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    private Vector3 respawnPosition1 = new Vector3(106.45f, 2.026628f, 138.7f);
    private Vector3 respawnPosition2 = new Vector3(123.47f, 2.026628f, 124.226f);

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lakearea")
        {
            Vector3 respawnPosition = transform.position.x < 120 ? respawnPosition1 : respawnPosition2;
            transform.position = respawnPosition;
        }
    }
}