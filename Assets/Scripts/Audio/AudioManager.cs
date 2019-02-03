using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource _audioSource;

    private static AudioClip _runAudio;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _runAudio = Resources.Load<AudioClip>("step");
    }

    public static void PlayAudio(string audioName)
    {
        switch (audioName)
        {
            case "run":
                _audioSource.PlayOneShot(_runAudio);
                break;

            default:
                break;
        }
    }
}
