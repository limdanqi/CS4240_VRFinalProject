using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimationController : MonoBehaviour
{
    Animator animator;
    string tag;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        tag = gameObject.tag + "area";
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            animator.SetBool("isWrongHabitat", false);
        }
        else
        {
            animator.SetBool("isWrongHabitat", true);
        }
    }
}
