using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemovalTutorialScript : MonoBehaviour
{
    public GameObject hintText;
    public GameObject successText;
    public GameObject failureText;

    public GameObject invasiveAnimal;
    public GameObject normalAnimal;

    private RemovalAnimalScript invasiveAnimalScript;
    private RemovalAnimalScript normalAnimalScript;

    private bool isInvasiveAnimalFirstKilled = false;
    private bool isNormalAnimalFirstKilled = false;

    void Start()
    {
        ResetText();

        invasiveAnimalScript = invasiveAnimal.GetComponent<RemovalAnimalScript>();
        normalAnimalScript = normalAnimal.GetComponent<RemovalAnimalScript>();

    }

    private void Update()
    {
        if (invasiveAnimalScript.isKilled && !isInvasiveAnimalFirstKilled)
        {
            Debug.Log("invasive killed");
            isInvasiveAnimalFirstKilled = true;
            hintText.SetActive(false);
            successText.SetActive(true);
            failureText.SetActive(false);
            StartCoroutine(RespawnAnimal(invasiveAnimal, true));

            Debug.Log("invasive reset");
        }

        if (normalAnimalScript.isKilled && !isNormalAnimalFirstKilled)
        {
            Debug.Log("normal killed");
            isNormalAnimalFirstKilled = true;
            hintText.SetActive(false);
            successText.SetActive(false);
            failureText.SetActive(true);
            StartCoroutine(RespawnAnimal(normalAnimal, false));
            Debug.Log("normal reset");
        }

    }

    private void ResetText()
    {
        hintText.SetActive(true);
        successText.SetActive(false);
        failureText.SetActive(false);
    }


    IEnumerator RespawnAnimal(GameObject animal, bool isInvasive)
    {
        Debug.Log("waiting starts");
        yield return new WaitForSeconds(5); // Wait for 5 seconds
        Debug.Log("waiting ends");
        animal.SetActive(true);
        animal.GetComponent<RemovalAnimalScript>().isKilled = false;
        if (isInvasive)
        {
            isInvasiveAnimalFirstKilled = false;
        }
        else
        {
            isNormalAnimalFirstKilled = false;
        }
        ResetText();
        Debug.Log("animal is " + animal.activeSelf);
        Debug.Log("animal kill status " + animal.GetComponent<RemovalAnimalScript>().isKilled);
        Debug.Log("invasive first " + isInvasiveAnimalFirstKilled);
        Debug.Log("normal first " + isNormalAnimalFirstKilled);

    }
}
