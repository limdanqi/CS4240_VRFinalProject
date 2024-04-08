using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTimerCounterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private GameObject counter;

    // Start is called before the first frame update
    void Start()
    {
        timer.SetActive(false);
        counter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        timer.SetActive(true);
        counter.SetActive(true);
    }
}
