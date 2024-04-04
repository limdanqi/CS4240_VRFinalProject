using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocationController : MonoBehaviour
{
    private GameObject animal;
    private bool isCorrectHabitat;
    public string habitatTag;
    
    // Start is called before the first frame update
    void Start()
    {
        animal = GameObject.FindGameObjectWithTag(habitatTag);
        isCorrectHabitat = IsInCorrectHabitat(animal, habitatTag);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (habitatTag.EndsWith("area")) {
            if (!isCorrectHabitat) {
                if (other.gameObject.CompareTag(habitatTag))
                {
                    CounterController.IncrementRelocate();
                    isCorrectHabitat = !isCorrectHabitat;
                }
            } else {
                if (!other.gameObject.CompareTag(habitatTag))
                {
                    CounterController.DecrementRelocate();
                    isCorrectHabitat = !isCorrectHabitat;
                }
            }
        }
    }

    bool IsInCorrectHabitat(GameObject animal, string habitatTag)
    {
        Collider collider = animal.GetComponent<Collider>();
        if (collider != null && collider.bounds.Contains(animal.transform.position))
        {
            return true;
        }
        return false;
    }
}
