using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasiveController : MonoBehaviour
{   
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        DecrementInvasive();
        Destroy(gameObject);
    }

    void DecrementInvasive()
    {
        CounterController.DecrementInvasive();
    }
}
