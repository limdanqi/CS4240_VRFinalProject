using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public const string ANIM_PARAM_NAME_FLEX = "Flex";
    public const string ANIM_PARAM_NAME_PINCH = "Pinch";

    [SerializeField]
    private InputActionProperty pinchAnimationAction;

    [SerializeField]
    private InputActionProperty flexAnimationAction;

    [SerializeField]
    private Animator handAnimator;

    // Update is called once per frame
    void Update()
    {
        // Animate pinch action
        float pinchValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat(ANIM_PARAM_NAME_PINCH, pinchValue);

        // Animate flex action
        float flexValue = flexAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat(ANIM_PARAM_NAME_FLEX, flexValue);
    }
}
