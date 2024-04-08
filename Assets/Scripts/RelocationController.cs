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
        splashSound = splashSoundObj.GetComponent<SplashSound>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (habitatTag.EndsWith("area")) {
            if (!isCorrectHabitat) {
                if (other.gameObject.CompareTag(habitatTag))
                {
                    CounterController.IncrementRelocate();
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
