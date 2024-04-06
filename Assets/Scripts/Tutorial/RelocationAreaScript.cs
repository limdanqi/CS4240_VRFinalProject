using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocationAreaScript : MonoBehaviour
{
    public bool isAnimalPresent = false;
    public bool isCorrectAnimalPresent = false;

    [SerializeField]
    private GameObject correctAnimal;

    [SerializeField]
    private string TAG_ANIMAL;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(TAG_ANIMAL))
        {
            isAnimalPresent = true;
            if (other.gameObject == correctAnimal)
            {
                isCorrectAnimalPresent = true;
            }
            else
            {
                isCorrectAnimalPresent = false;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        isAnimalPresent = false;
        isCorrectAnimalPresent = false;
    }



}
