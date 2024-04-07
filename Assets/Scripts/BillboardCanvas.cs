using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
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
            canvas.transform.rotation = rotation * Quaternion.Euler(0, 180f, 0);
        }
    }
}
