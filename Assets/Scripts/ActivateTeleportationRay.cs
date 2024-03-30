using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject teleportationRay;

    public InputActionProperty inputAction;

    void Update()
    {
        // Activates teleportation ray if input key is pressed
        teleportationRay.SetActive(inputAction.action.ReadValue<float>() > 0.1f);
    }
}
