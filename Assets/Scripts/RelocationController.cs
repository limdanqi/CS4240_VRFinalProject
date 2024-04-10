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
        animal = this.gameObject;
        isCorrectHabitat = IsInCorrectHabitat(animal, habitatTag);
        if (isCorrectHabitat) {
            Debug.Log(gameObject.name + " correct habitat");
        } else {
            Debug.Log(gameObject.name + " incorrect habitat");
        }
        splashSound = splashSoundObj.GetComponent<SplashSound>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.EndsWith("area")) {
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
                    Debug.Log("Decremented counter: " + habitatTag + " " + gameObject.name);
                    CounterController.DecrementRelocate();
                    isCorrectHabitat = !isCorrectHabitat;
                }
            }
        }
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
}
