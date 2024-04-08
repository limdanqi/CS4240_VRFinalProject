using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimationOnGrab : MonoBehaviour
{
    [SerializeField]
    private XRGrabInteractable interactableComponent;

    [SerializeField]
    private GameObject animatorObject;


    // Start is called before the first frame update
    void Start()
    {
        interactableComponent.selectEntered.AddListener(StopAnimation);
        interactableComponent.selectExited.AddListener(StartAnimation);

    }

    private void StopAnimation(SelectEnterEventArgs args)
    {
        if (animatorObject.GetComponent<Animator>() != null)
        {
            animatorObject.GetComponent<Animator>().enabled = false;
        }

    }

    private void StartAnimation(SelectExitEventArgs args)
    {
        if (animatorObject.GetComponent<Animator>() != null)
        {
            animatorObject.GetComponent<Animator>().enabled = true;
        }
    }
}
