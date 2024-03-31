using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickTutorialScript : MonoBehaviour
{
    public GameObject hintText;
    public GameObject successText;
    public GameObject wrongText;
    public GameObject water;

    public bool isSuccess = false;
    public bool isGoodWater;

    void Start()
    {
        hintText.SetActive(false);
        successText.SetActive(false);
        wrongText.SetActive(false);

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
                wrongText.SetActive(false);
            }
            else if (isSuccess && isGoodWater)
            {
                hintText.SetActive(false);
                successText.SetActive(true);
                wrongText.SetActive(false);
            }
            else if (isSuccess && !isGoodWater)
            {
                hintText.SetActive(false);
                successText.SetActive(false);
                wrongText.SetActive(true);

            }
        }
       
    }

}
