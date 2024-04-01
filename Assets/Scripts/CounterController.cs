using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterController : MonoBehaviour
{
    public static int totalRelocateAnimals;
    public static int rightHabitat;
    public static int invasiveRemaining;
    private TextMeshProUGUI counterText;

    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
        CountRelocateAnimals();
        CountRightHabitatAnimals();
        CountInvasiveAnimals();
        DisplayCounts();
    }

    void Update()
    {
        DisplayCounts();
    }

    void CountRelocateAnimals()
    {
        GameObject[] lakeAnimals = GameObject.FindGameObjectsWithTag("lake");
        GameObject[] barnAnimals = GameObject.FindGameObjectsWithTag("barn");
        GameObject[] forestAnimals = GameObject.FindGameObjectsWithTag("forest");

        List<GameObject> relocateAnimalsList = new List<GameObject>();
        relocateAnimalsList.AddRange(lakeAnimals);
        relocateAnimalsList.AddRange(barnAnimals);
        relocateAnimalsList.AddRange(forestAnimals);

        List<GameObject> filteredRelocateAnimals = new List<GameObject>();
        foreach (GameObject animal in relocateAnimalsList)
        {
            if (!animal.GetComponent<Collider>())
            {
                filteredRelocateAnimals.Add(animal);
            }
        }

        totalRelocateAnimals = filteredRelocateAnimals.Count;
    }

    void CountRightHabitatAnimals()
    {
        rightHabitat = 0;

        GameObject[] lakeAnimals = GameObject.FindGameObjectsWithTag("lake");
        GameObject[] barnAnimals = GameObject.FindGameObjectsWithTag("barn");
        GameObject[] forestAnimals = GameObject.FindGameObjectsWithTag("forest");

        rightHabitat += CountAnimalsInCorrectHabitat(lakeAnimals, "lake");
        rightHabitat += CountAnimalsInCorrectHabitat(barnAnimals, "barn");
        rightHabitat += CountAnimalsInCorrectHabitat(forestAnimals, "forest");
    }

    int CountAnimalsInCorrectHabitat(GameObject[] animals, string habitatTag)
    {
        int count = 0;
        foreach (GameObject animal in animals)
        {
            if (IsInCorrectHabitat(animal, habitatTag))
            {
                count++;
            }
        }
        return count;
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


    void CountInvasiveAnimals()
    {
        GameObject[] invasiveAnimals = GameObject.FindGameObjectsWithTag("Invasive");
        invasiveRemaining = invasiveAnimals.Length;
    }

    void DisplayCounts()
    {
        Debug.Log("Relocate: " + rightHabitat + " / " + totalRelocateAnimals);
        Debug.Log("Invasive: " + invasiveRemaining);
        string relocateText = rightHabitat + "/" + totalRelocateAnimals;
        string invasiveText = invasiveRemaining.ToString();
        counterText.text = relocateText + " " + invasiveRemaining; 
    }
}