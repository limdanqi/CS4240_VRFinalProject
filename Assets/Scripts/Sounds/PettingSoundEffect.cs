using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettingSoundEffect : MonoBehaviour
{
    public AudioSource pettingSoundSource; // Reference to the AudioSource component
    public AudioClip pettingSoundClip; // Sound to play when petting an animal

    public void PlayPettingSound()
    {
        pettingSoundSource.PlayOneShot(pettingSoundClip);
    }
}
