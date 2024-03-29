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
            Debug.Log("animator not null, stop anim");
            animatorObject.GetComponent<Animator>().enabled = false;
        }
        else
        {
            Debug.Log("animator null");
        }
    }

    private void StartAnimation(SelectExitEventArgs args)
    {
        if (animatorObject.GetComponent<Animator>() != null)
        {
            Debug.Log("animator not null, start anim");
            animatorObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
            Debug.Log("animator null");
        }
    }
}
