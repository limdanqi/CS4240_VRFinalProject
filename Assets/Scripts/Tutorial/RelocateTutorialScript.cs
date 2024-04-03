using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RelocateTutorialScript : MonoBehaviour
{
    public GameObject hintText;
    public GameObject successText;
    public GameObject wrongText;

    public GameObject correctArea;
    public GameObject wrongArea;

    private RelocationAreaScript correctRelocationAreaScript;
    private RelocationAreaScript wrongRelocationAreaScript;

    void Start()
    {
        hintText.SetActive(true);
        successText.SetActive(false);
        wrongText.SetActive(false);

        correctRelocationAreaScript = correctArea.GetComponent<RelocationAreaScript>();
        wrongRelocationAreaScript = wrongArea.GetComponent<RelocationAreaScript>();
    }

    private void Update()
    {
        if (correctRelocationAreaScript.isCorrectAnimalPresent)
        {
            hintText.SetActive(false);
            successText.SetActive(true);
            wrongText.SetActive(false);
        }

        if (wrongRelocationAreaScript.isAnimalPresent && !wrongRelocationAreaScript.isCorrectAnimalPresent)
        {
            hintText.SetActive(false);
            successText.SetActive(false);
            wrongText.SetActive(true);
        }

        if (!correctRelocationAreaScript.isAnimalPresent && !wrongRelocationAreaScript.isAnimalPresent)
        {
            hintText.SetActive(true);
            successText.SetActive(false);
            wrongText.SetActive(false);
        }
    }

}
