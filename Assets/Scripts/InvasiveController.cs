using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasiveController : MonoBehaviour
{   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            kill();
            Destroy(other.gameObject);
        }
    }

    public void kill() {
        DecrementCounter();
        Destroy(gameObject);
    }

    void DecrementCounter()
    {
        InvasiveManager.DecrementCounter();
    }
}
