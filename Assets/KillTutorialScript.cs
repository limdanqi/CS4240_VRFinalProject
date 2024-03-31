using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillTutorialScript : MonoBehaviour
{
    public GameObject hintText;
    public GameObject successText;
    public GameObject failureText;
    public GameObject againText;
    public GameObject sparrow;

    private Vector3 sparrowPos;
    private Quaternion sparrowRot;

    private bool isSuccess = false;
    private bool isFailure = false;
    private bool isAgain = false;

    void Start()
    {
        hintText.SetActive(false);
        successText.SetActive(false);
        failureText.SetActive(false);
        againText.SetActive(false);
        sparrowPos = sparrow.transform.position;
        sparrowRot = sparrow.transform.rotation;

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered");
            if (!isSuccess && !isFailure && !isAgain)
            {
                Debug.Log("everyone still inside");
                hintText.SetActive(true);
                successText.SetActive(false);
                failureText.SetActive(false);
                againText.SetActive(false);
            } else if (isSuccess)
            {
                hintText.SetActive(false);
                successText.SetActive(true);
                failureText.SetActive(false);
                againText.SetActive(false);
            }
            else if (isAgain)
            {
                hintText.SetActive(false);
                successText.SetActive(false);
                failureText.SetActive(false);
                againText.SetActive(true);
            }
            else if (isFailure)
            {
                hintText.SetActive(false);
                successText.SetActive(false);
                failureText.SetActive(true);
                againText.SetActive(false);
            } 
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            isFailure = true;
            StartCoroutine(RespawnAnimal());
        }

        if (other.gameObject.CompareTag("Invasive") && !isFailure)
        {
            isAgain = false;
            isFailure = false;
            isSuccess = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            hintText.SetActive(false);
            successText.SetActive(false);
            failureText.SetActive(false);
        }
    }
    IEnumerator RespawnAnimal()
    {
        yield return new WaitForSeconds(10); // Wait for 10 seconds
        Instantiate(sparrow, sparrowPos, sparrowRot); // Respawn the animal
        isAgain = true;
        isFailure = false;
    }
}
