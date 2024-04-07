using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSoundEffects : MonoBehaviour
{
    public static TimerSoundEffects instance; // Singleton instance
    public AudioSource startSoundSource; // AudioSource for the start sound
    public AudioSource endSoundSource; // AudioSource for the end sound
    public AudioClip gameStartSound; // Sound to play at the start of the game
    public AudioClip gameEndSound; // Sound to play at the end of the game

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayGameStartSound()
    {
        startSoundSource.PlayOneShot(gameStartSound);
    }

    public void PlayGameEndSound()
    {
        endSoundSource.PlayOneShot(gameEndSound);
    }
}
