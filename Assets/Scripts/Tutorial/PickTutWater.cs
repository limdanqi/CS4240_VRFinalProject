using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTutWater : MonoBehaviour
{
    public bool isGoodWater;
    PickTutorialScript parentScript;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<PickTutorialScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (parentScript != null)
        {
            if (other.CompareTag("lake"))
            {
                parentScript.isSuccess = true;
                parentScript.isGoodWater = isGoodWater;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (parentScript != null)
        {
            if (other.CompareTag("lake"))
            {
                parentScript.isSuccess = false;
            }
        }
    }
}