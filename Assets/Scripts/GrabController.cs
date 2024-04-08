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
            navMeshAgent.enabled = false;
            randomMovement.SetIsGrabbing();
        }

    }

    public void EnableNav()
    {
<<<<<<< HEAD
        randomMovement.StopGrabbing(); ;
        navMeshAgent.ResetPath();
=======
        if (navMeshAgent != null && randomMovement != null)
        {
            navMeshAgent.enabled = true;
            randomMovement.StopGrabbing(); ;
            navMeshAgent.ResetPath();
        }

>>>>>>> 5557eeb22dc9434915655f9d313448e901dc542a
    }
}
