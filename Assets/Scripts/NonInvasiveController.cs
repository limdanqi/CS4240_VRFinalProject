using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonInvasiveController : MonoBehaviour
{
    public GameObject soundObj;
    private KillNonInvasiveEffect soundController;
    // Start is called before the first frame update
    void Start()
    {
        soundController = soundObj.GetComponent<KillNonInvasiveEffect>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("SHOT WRONG ANIMAL");
            soundController.PlayKillNonInvasiveSound();
        }
    }
}
