using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverAnimationController : MonoBehaviour
{
    public Animation animationComponent;
    public string hoverAnimationName = "Sweat_L";

    private XRBaseInteractable interactable;

    private void Start()
    {
        // Get reference to the XRBaseInteractable component
        interactable = GetComponent<XRBaseInteractable>();

        // Add listeners for hover events
        interactable.hoverEntered.AddListener(PlayHoverAnimation);
        interactable.hoverExited.AddListener(StopHoverAnimation);
    }

    public void PlayHoverAnimation(HoverEnterEventArgs args)
    {
        // Check if the animation component is valid and play the hover animation
        if (animationComponent != null)
        {
            animationComponent.Play(hoverAnimationName);
        }
    }

    public void StopHoverAnimation(HoverExitEventArgs args)
    {
        // Check if the animation component is valid and stop the animation
        if (animationComponent != null)
        {
            animationComponent.Stop();
        }
    }
}