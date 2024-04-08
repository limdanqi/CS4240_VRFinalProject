using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    RandomMovement randomMovement;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        randomMovement = GetComponent<RandomMovement>();
    }

    public void DisableNav()
    {

        if (navMeshAgent != null && randomMovement != null)
        {
            navMeshAgent.ResetPath();
            randomMovement.SetIsGrabbing();
        }

    }

    public void EnableNav()
    {
        if (navMeshAgent != null && randomMovement != null)
        {
            randomMovement.StopGrabbing(); ;
            navMeshAgent.ResetPath();
        }
    }
}
