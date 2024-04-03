using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovalAnimalScript : MonoBehaviour
{
    public bool isKilled = false;

    private const string TAG_BULLET = "Bullet";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TAG_BULLET))
        {
            isKilled = true;
            gameObject.SetActive(false);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag(TAG_BULLET))
    //    {
    //        if (invasiveSpecies)
    //        {
    //            hasValidKill = true;
    //        }
    //        else
    //        {
    //            hasValidKill = false;
    //        }
    //        gameObject.SetActive(false);
    //    }
    //}
}
