using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRayInteractor : MonoBehaviour
{
    [SerializeField]
    private GameObject rayInteractor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        rayInteractor.SetActive(true);
    }
}
