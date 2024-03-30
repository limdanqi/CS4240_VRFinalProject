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

    private void Start()
    {
        gunObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressing && toggleGunAction.action.IsPressed())
        {
            isPressing = true;

            if (isToggleOn)
            {
                // Hide Gun
                isToggleOn = false;
                gunObject.SetActive(false);

                // Revert to original hand pose
                GetComponent<GrabGunHandPose>().RevertGunPose();
            }
            else
            {
                // Show Gun
                isToggleOn = true;
                gunObject.SetActive(true);

                // Change to gun pose
                GetComponent<GrabGunHandPose>().SetupGunPose();
            }

        }

        if (toggleGunAction.action.WasReleasedThisFrame())
        {
            isPressing = false;
        }

    }
}
