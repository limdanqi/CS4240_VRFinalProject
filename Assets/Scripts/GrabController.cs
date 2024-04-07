using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabController : MonoBehaviour
{
    GameObject grabbed;
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableNav()
    {
        navMeshAgent.ResetPath();
        navMeshAgent.enabled = false;
    }

    public void EnableNav()
    {
        navMeshAgent.enabled = true;
        navMeshAgent.ResetPath();
    }
}
