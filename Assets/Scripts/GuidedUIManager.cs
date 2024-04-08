using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedUIManager : MonoBehaviour
{
    public bool isGuidedMode;
    private Rigidbody rb;
    public Canvas InvasiveUIPopup;
    public Canvas HabitatUIPopup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (InvasiveUIPopup != null)
        {
            InvasiveUIPopup.enabled = false;
        }
        HabitatUIPopup.enabled = isGuidedMode;
        isGuidedMode = true; // set as true by default
    }


    // Update is called once per frame
    void Update()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;
            Vector3 correctedDirection = Vector3.ProjectOnPlane(directionToCamera, transform.up);
            Quaternion rotation = Quaternion.LookRotation(correctedDirection, transform.up);
            HabitatUIPopup.transform.rotation = rotation * Quaternion.Euler(0, 180f, 0);
            if (InvasiveUIPopup != null)
            {
                InvasiveUIPopup.transform.rotation = rotation * Quaternion.Euler(0, 180f, 0);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isGuidedMode && other.gameObject.CompareTag("Bullet") && gameObject.tag != "Invasive")
        {
            AnimalController.IncrementKillCounter();
            EnableInvasiveCanvas();
            Invoke("DisableInvasiveCanvas", 2f);

        }
    }

    void EnableInvasiveCanvas()
    {
        HabitatUIPopup.enabled = false;
        if (InvasiveUIPopup != null)
        {
            InvasiveUIPopup.enabled = true;
        }
    }

    void DisableInvasiveCanvas()
    {
        if (InvasiveUIPopup != null)
        {
            InvasiveUIPopup.enabled = false;
        }
        HabitatUIPopup.enabled = true;
    }
}
