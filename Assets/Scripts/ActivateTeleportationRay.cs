using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;

    public InputActionProperty leftActivate;

    void Update()
    {
        // Activates left teleportation ray if input key is pressed
        leftTeleportation.SetActive(leftActivate.action.ReadValue<float>() > 0.1f);
    }
}
