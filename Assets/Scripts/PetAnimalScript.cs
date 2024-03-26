using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAnimalScript : MonoBehaviour
{
    public OVRInput.Controller Controller;

    public string petButtonName;
    public float petRadius;
    public LayerMask animalMask;

    private GameObject currentAnimal;
    private Animator currAnimalAnimator;
    private bool isPetting;

    void Update()
    {
        if (Input.GetAxis(petButtonName) > 0)
        {
            RaycastHit[] hits;

            hits = Physics.SphereCastAll(transform.position, petRadius, transform.forward, 0.05f, animalMask);
            if (hits.Length > 0)
            {
                isPetting = true;
            } else
            {
                isPetting = false;
            }
                
        } else
        {
            isPetting = false;
        }

        if (isPetting)
        {
            PetAnimal();
        } else
        {
            StopPettingAnimal();
        }
    }

    // For debugging
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, petRadius);
    }

    void PetAnimal()
    {
        RaycastHit[] hits;

        hits = Physics.SphereCastAll(transform.position, petRadius, transform.forward, 0.05f, animalMask);
        if (hits.Length > 0)
        {
            int closestHit = 0;

            for (int i = 0; i < hits.Length; i++)
            {
                if ((hits[i]).distance < hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }
            GameObject currPettingObj = hits[closestHit].transform.gameObject;
            currentAnimal = currPettingObj;
            ParticleSystem currentAnimalParticleSystem = currentAnimal.GetComponentInChildren<ParticleSystem>();
            if (currentAnimalParticleSystem != null && !currentAnimalParticleSystem.isPlaying) {
                currentAnimalParticleSystem.Play();
            }
            
            currAnimalAnimator = currPettingObj.GetComponent<Animator>();

            currAnimalAnimator.SetBool("IsPetting", true);

        }
    }

    private void StopPettingAnimal()
    {
        if (currAnimalAnimator != null)
        {
            currAnimalAnimator.SetBool("IsPetting", false);
            ParticleSystem currentAnimalParticleSystem = currentAnimal.GetComponentInChildren<ParticleSystem>();
            if (currentAnimalParticleSystem != null && currentAnimalParticleSystem.isPlaying)
            {
                currentAnimalParticleSystem.Stop();
            }

            
        }
        
    }
}
