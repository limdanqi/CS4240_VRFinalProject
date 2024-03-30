using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleGunOnInput : MonoBehaviour
{
    [SerializeField]
    private GameObject gunObject;

    [SerializeField]
    private InputActionProperty toggleGunAction;

    private bool isToggleOn = false;
    private bool isPressing = false;

    // Update is called once per frame
    void Update()
    {
        if (!isPressing && toggleGunAction.action.IsPressed())
        {
            isPressing = true;

            if (isToggleOn)
            {
                isToggleOn = false;
                gunObject.SetActive(false);
            }
            else
            {
                isToggleOn = true;
                gunObject.SetActive(true);
            }

        }

        if (toggleGunAction.action.WasReleasedThisFrame())
        {
            isPressing = false;
        }

    }
}
