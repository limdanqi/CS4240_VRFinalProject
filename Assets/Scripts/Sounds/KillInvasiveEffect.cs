using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillInvasiveEffect : MonoBehaviour
{
    public AudioSource killSoundSource; // Reference to the AudioSource component
    public AudioClip killInvasiveSoundClip; // Sound to play when killing invasive animals

    public void PlayKillInvasiveSound()
    {
        killSoundSource.PlayOneShot(killInvasiveSoundClip);
    }
}
