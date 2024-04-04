using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocationController : MonoBehaviour
{
    private bool isCorrectHabitat;
    private GameObject animal;
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
        UpdateRelocation();
    }

    bool IsInCorrectHabitat(GameObject animal, string habitatTag)
    {
        GameObject[] habitatObjects = GameObject.FindGameObjectsWithTag(habitatTag);
        
        foreach (GameObject habitatObject in habitatObjects)
        {
            Collider collider = habitatObject.GetComponent<Collider>();
            if (collider != null && collider.bounds.Contains(animal.transform.position))
            {
                return true;
            }
        }
        return false;
    }

    public void UpdateRelocation() {
        bool updatedHabitat = IsInCorrectHabitat(animal, habitatTag);
        
        // initially correct, now incorrect
        if (isCorrectHabitat && !updatedHabitat) {
            CounterController.DecrementRelocate();
        }
        // initially incorrect, now correct
        else if (!isCorrectHabitat && updatedHabitat) {
            CounterController.IncrementRelocate();
        }
    }
}
