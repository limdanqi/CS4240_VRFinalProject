using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillNonInvasiveEffect : MonoBehaviour
{
    public AudioSource killSoundSource; // Reference to the AudioSource component
    public AudioClip killNonInvasiveSoundClip; // Sound to play when killing non-invasive animals

    public void PlayKillNonInvasiveSound()
    {
        killSoundSource.PlayOneShot(killNonInvasiveSoundClip);
    }
}

