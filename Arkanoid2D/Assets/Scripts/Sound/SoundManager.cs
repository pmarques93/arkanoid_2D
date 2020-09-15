using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Sounds
    private static AudioClip[] sounds;

    private static AudioSource audioSource;

    void Start()
    {
        sounds = new AudioClip[3];
        audioSource = GetComponent<AudioSource>();


        sounds[0] = Resources.Load<AudioClip>("Sounds/shoot");
        sounds[1] = Resources.Load<AudioClip>("Sounds/hit");
        sounds[2] = Resources.Load<AudioClip>("Sounds/powerup");
    }

    // Plays a sound depending on the clip parameter
    public static void PlaySound(SoundClips clip)
    {
        switch (clip)
        {
            case SoundClips.shoot:
                audioSource.PlayOneShot(sounds[0], 0.7f);
                break;
            case SoundClips.hit:
                audioSource.PlayOneShot(sounds[1], 0.5f);
                break;
            case SoundClips.powerup:
                audioSource.PlayOneShot(sounds[2], 0.5f);
                break;
        }
    }
}
