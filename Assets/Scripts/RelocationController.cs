using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RelocationController : MonoBehaviour
{
    private GameObject animal;
    private bool isCorrectHabitat;
    public string habitatTag;

    public GameObject splashSoundObj;
    private SplashSound splashSound;
    
    // Start is called before the first frame update
    void Start()
    {
        animal = GameObject.FindGameObjectWithTag(habitatTag);
        isCorrectHabitat = IsInCorrectHabitat(animal, habitatTag);
        if (isCorrectHabitat) {
            Debug.Log("correct habitat");
        } else {
            Debug.Log("incorrect habitat");
        }
        splashSound = splashSoundObj.GetComponent<SplashSound>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (habitatTag.EndsWith("area")) {
            Debug.Log("detects other colider with sth that ends in area");
            if (!isCorrectHabitat) {
                Debug.Log("initially incorrect");
                if (other.gameObject.CompareTag(habitatTag))
                {
                    CounterController.IncrementRelocate();
                    Debug.Log("increment counter");
                    isCorrectHabitat = !isCorrectHabitat;
                    if (habitatTag =="lakearea")
                    {
                        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
                        ParticleSystem splashParticles = particleSystems.ToList().Find(p => p.name == "Splash");
                        splashParticles.Play();
                        if (splashSound)
                        {
                            splashSound.PlaySplashSound();
                        }
                    }
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
