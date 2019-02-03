using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioThemeSong : MonoBehaviour
{
    private AudioSource _audioSource;

    private AudioClip _themeSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _themeSound = Resources.Load<AudioClip>("theme_song");

        _audioSource.loop = true;

        _audioSource.PlayOneShot(_themeSound);
    }
}
