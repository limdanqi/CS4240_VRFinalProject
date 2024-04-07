using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimationController : MonoBehaviour
{
    Animator animator;
    string tag;
    public ParticleSystem happyParticles;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        tag = gameObject.tag + "area";
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(tag) && !other.gameObject.CompareTag("Player"))
        {
            happyParticles.Play();
            animator.SetBool("isWrongHabitat", false);
        }
        else
        {
            happyParticles.Stop();
            animator.SetBool("isWrongHabitat", true);
        }
    }
}
