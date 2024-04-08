using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSound : MonoBehaviour
{
    public AudioSource splashSource;
    public AudioClip splashSound;
    
    public void PlaySplashSound()
    {
        splashSource.PlayOneShot(splashSound);
    }
}
