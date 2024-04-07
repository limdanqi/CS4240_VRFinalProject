using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Terrain" || other.gameObject.CompareTag("Teleport Area"))
        {
            Debug.Log("terrain hit");
            gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.rotation.y, 0);
        }
    }
}
