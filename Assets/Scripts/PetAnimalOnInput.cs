using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PetAnimalOnInput : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty petAction;

    [SerializeField]
    private XRDirectInteractor interactor;

    private const string ANIM_PARAM_IS_PETTING = "IsPetting";

    // Update is called once per frame
    void Update()
    {
        if (interactor.hasHover)
        {
            if (petAction.action.IsPressed()) // only interactables in environment are animals
            {
                SetAnimalPetAnimation(interactor.interactablesHovered, true);
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
        }
    }
}