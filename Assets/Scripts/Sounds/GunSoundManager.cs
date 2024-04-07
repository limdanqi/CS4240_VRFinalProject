using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSoundManager : MonoBehaviour
{
    public AudioSource soundEffectSource; // Reference to the AudioSource component
    public AudioClip gunSoundClip; // Reference to the gun sound effect AudioClip

    // Play the gun sound effect
    public void PlayGunSound()
    {
        soundEffectSource.PlayOneShot(gunSoundClip);
    }
}
