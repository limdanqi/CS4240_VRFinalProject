using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasiveController : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            kill();
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
