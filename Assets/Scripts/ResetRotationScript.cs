using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotationScript : MonoBehaviour
{
    public ParticleSystem dropDust;
    private bool isCheckRotation = false;

    public void CheckRotationAfterDrop()
    {
        isCheckRotation = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.name == "Terrain" || other.gameObject.CompareTag("Teleport Area")) && isCheckRotation)
        {
            Debug.Log(isCheckRotation);
            if (transform.position.y >= 1)
            {
                // only applies to dropping on land
                dropDust.Play();
            }
            float xRotate = gameObject.transform.rotation.x;
            float zRotate = gameObject.transform.rotation.z;
            if (xRotate != 0 && zRotate != 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.rotation.y, 0);
            }
            isCheckRotation = false;
        }
    }
}
