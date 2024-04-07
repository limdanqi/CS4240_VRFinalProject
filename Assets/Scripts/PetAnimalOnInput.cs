using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.AI;

public class PetAnimalOnInput : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty petAction;

    [SerializeField]
    private XRDirectInteractor interactor;

    private const string ANIM_PARAM_IS_PETTING = "isPetting";

    public PettingSoundEffect pettingSoundEffect; // Reference to the PettingSoundEffect component

    // Update is called once per frame
    void Update()
    {
        if (interactor.hasHover)
        {
            if (petAction.action.IsPressed()) // only interactables in environment are animals
            {
                SetAnimalPetAnimation(interactor.interactablesHovered, true);

                if (pettingSoundEffect != null)
                {
                    pettingSoundEffect.PlayPettingSound(); // Play petting sound
                }
            }

            if (petAction.action.WasReleasedThisFrame())
            {
                SetAnimalPetAnimation(interactor.interactablesHovered, false);
            }
        }
    }

    private void SetAnimalPetAnimation(List<IXRHoverInteractable> animalsHovered, bool isPetting)
    {
        for (int i = 0; i < animalsHovered.Count; i++)
        {
            Animator animator = animalsHovered[i].transform.gameObject.GetComponentInChildren<Animator>();
            animator.SetBool(ANIM_PARAM_IS_PETTING, isPetting);
            ParticleSystem particle = animalsHovered[i].transform.gameObject.GetComponentInChildren<ParticleSystem>();
            NavMeshAgent agent = animalsHovered[i].transform.gameObject.GetComponentInChildren<NavMeshAgent>();
            if (isPetting)
            {
                if (agent != null)
                {
                    agent.isStopped = true;
                }
                particle.Play();
            }
            else
            {
                if (agent != null)
                {
                    agent.isStopped = false;

                }
                particle.Stop();
            }

        }
    }
}
