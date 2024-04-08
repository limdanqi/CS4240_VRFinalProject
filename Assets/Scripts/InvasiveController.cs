using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasiveController : MonoBehaviour
{
    public GameObject killInvasiveObj;
    private KillInvasiveEffect killInvasiveEffect;

    private void Start()
    {
        killInvasiveEffect = killInvasiveObj.GetComponent<KillInvasiveEffect>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            kill();
        }
    }

    public void kill() {
        if (killInvasiveEffect)
        {
            killInvasiveEffect.PlayKillInvasiveSound();
        }
        DecrementCounter();
        AnimalController.IncrementKillCounter();
        Destroy(gameObject);
    }

    void DecrementCounter()
    {
        CounterController.DecrementCounter();
    }
}
