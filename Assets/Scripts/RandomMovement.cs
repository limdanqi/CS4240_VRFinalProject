using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    private bool isWaiting;

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    private bool isGrabbed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if(!isGrabbed && !isWaiting && agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            StartCoroutine(WaitAndSetDestination(2.0f));
        }

    }

    public void SetIsGrabbing()
    {
        isGrabbed = true;
    }

    public void StopGrabbing()
    {
        isGrabbed = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(centrePoint.position, range);
    }
    private IEnumerator WaitAndSetDestination(float waitTime)
    {
        isWaiting = true; // Set the flag to true
        yield return new WaitForSeconds(waitTime); // Wait for the specified time

        Vector3 point;
        if (RandomPoint(centrePoint.position, range, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); // Visualize the destination point
            agent.SetDestination(point); // Set the agent's destination
        }
        isWaiting = false; // Reset the flag
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isGrabbed && 
            collision.gameObject != this && 
            collision.gameObject.name != "Terrain" && 
            !collision.gameObject.CompareTag("Teleport Area"))
        {
            agent.ResetPath();
            isWaiting = false;
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }


}
