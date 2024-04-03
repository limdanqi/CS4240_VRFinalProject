using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasiveAnimationController : MonoBehaviour
{
    Animator animator;
    private int attackCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isNearOthers", attackCount > 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lake") ||
            other.gameObject.CompareTag("barn") ||
            other.gameObject.CompareTag("farm") ||
            other.gameObject.CompareTag("forest"))
        {
            attackCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("lake") ||
            other.gameObject.CompareTag("barn") ||
            other.gameObject.CompareTag("farm") ||
            other.gameObject.CompareTag("forest"))
        {
            attackCount--;
        }
    }
}
