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
        InvasiveUIPopup.enabled = false;
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
            InvasiveUIPopup.transform.rotation = rotation * Quaternion.Euler(0, 180f, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isGuidedMode && other.gameObject.CompareTag("Bullet") && gameObject.tag != "Invasive")
        {
            EnableInvasiveCanvas();
            Invoke("DisableInvasiveCanvas", 2f);

        }
    }

    void EnableInvasiveCanvas()
    {
        HabitatUIPopup.enabled = false;
        InvasiveUIPopup.enabled = true;
    }

    void DisableInvasiveCanvas()
    {
        InvasiveUIPopup.enabled = false;
        HabitatUIPopup.enabled = true;
    }
}
