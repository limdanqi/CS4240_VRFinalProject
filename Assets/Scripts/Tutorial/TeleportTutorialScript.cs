using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTutorialScript : MonoBehaviour
{
    [SerializeField]
    private GameObject teleportBox1;
    [SerializeField]
    private GameObject teleportBox2;
    [SerializeField]
    private GameObject teleportBox3;

    [SerializeField]
    private GameObject hintText;
    [SerializeField]
    private GameObject successText1;
    [SerializeField]
    private GameObject successText2;
    [SerializeField]
    private GameObject successText3;

    private TeleportAreaScript teleportAreaScript1;
    private TeleportAreaScript teleportAreaScript2;
    private TeleportAreaScript teleportAreaScript3;


    // Start is called before the first frame update
    void Start()
    {
        teleportBox1.SetActive(true);
        teleportBox2.SetActive(false);
        teleportBox3.SetActive(false);

        hintText.SetActive(true);
        successText1.SetActive(false);
        successText2.SetActive(false);
        successText3.SetActive(false);

        teleportAreaScript1 = teleportBox1.GetComponent<TeleportAreaScript>();
        teleportAreaScript2 = teleportBox2.GetComponent<TeleportAreaScript>();
        teleportAreaScript3 = teleportBox3.GetComponent<TeleportAreaScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportAreaScript1.hasEnteredArea)
        {
            hintText.SetActive(false);
            successText1.SetActive(true);
            teleportBox2.SetActive(true);
        }

        if (teleportAreaScript2.hasEnteredArea)
        {
            successText2.SetActive(true);
            teleportBox3.SetActive(true);
        }

        if (teleportAreaScript3.hasEnteredArea)
        {
            successText3.SetActive(true);
        }

    }


}
