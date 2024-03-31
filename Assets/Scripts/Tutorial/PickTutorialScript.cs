using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickTutorialScript : MonoBehaviour
{
    public GameObject hintText;
    public GameObject successText;
    public GameObject water;

    public bool isSuccess = false;

    void Start()
    {
        hintText.SetActive(false);
        successText.SetActive(false);

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered");
            if (!isSuccess)
            {
                hintText.SetActive(true);
                successText.SetActive(false);
            }
            else if (isSuccess)
            {
                hintText.SetActive(false);
                successText.SetActive(true);
            }
        }
       
    }

}
