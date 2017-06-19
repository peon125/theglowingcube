using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController03 : MonoBehaviour 
{
    public AudioClip intro, track;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = intro;
        _audioSource.Play();
    }

    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = track;
            _audioSource.Play();
        }
    }
}