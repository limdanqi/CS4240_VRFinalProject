using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTutorialScript : MonoBehaviour
{
    [SerializeField]
    private GameObject hintText;
    [SerializeField]
    private GameObject successText;

    [SerializeField]
    private GameObject animal1;
    [SerializeField]
    private GameObject animal2;

    private PetAnimalTutorialScript petAnimal1;
    private PetAnimalTutorialScript petAnimal2;

    // Start is called before the first frame update
    void Start()
    {
        hintText.SetActive(true);
        successText.SetActive(false);

        petAnimal1 = animal1.GetComponent<PetAnimalTutorialScript>();
        petAnimal2 = animal2.GetComponent<PetAnimalTutorialScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (petAnimal1.isPetting || petAnimal2.isPetting)
        {
            hintText.SetActive(false);
            successText?.SetActive(true);
        }
    }
}
