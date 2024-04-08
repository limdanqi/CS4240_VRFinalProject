using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSound : MonoBehaviour
{
    public AudioSource dropSource;
    public AudioClip dropSound;

    public void PlayDropSound()
    {
        dropSource.PlayOneShot(dropSound);
    }
}