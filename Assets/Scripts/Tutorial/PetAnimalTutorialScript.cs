using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PetAnimalTutorialScript : MonoBehaviour
{
    public bool isPetting = false;

    private const string ANIM_PARAM_IS_PETTING = "isPetting";
    private XRSimpleInteractable interactable;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        animator = gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.isHovered && animator.GetBool(ANIM_PARAM_IS_PETTING))
        {
            isPetting = true;
        }
        else
        {
            isPetting = false;
        }
    }


}
