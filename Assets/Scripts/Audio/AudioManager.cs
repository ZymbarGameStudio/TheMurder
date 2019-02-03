using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource _audioSource;

    private static AudioClip _runSound;
    private static AudioClip _coinSound;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _runSound = Resources.Load<AudioClip>("step");
        _coinSound = Resources.Load<AudioClip>("coin");
    }

    public static void PlayAudio(string audioName)
    {
        switch (audioName)
        {
            case "run":
                _audioSource.PlayOneShot(_runSound);
                break;

            case "coin":
                _audioSource.PlayOneShot(_coinSound);
                break;

            default:
                break;
        }
    }
}
