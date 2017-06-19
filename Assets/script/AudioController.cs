using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour 
{
    public static AudioController _instance;
    public AudioClip musicInBackground, objective, chargeOfEnergy, boost, checkpoint;
    public GameObject jinglePrefab;
    AudioSource audioSource;

    void Awake()
    {
        _instance = this;
    }

    public void PlaySound(string s)
    {
        GameObject jingle = Instantiate(jinglePrefab, transform);
        AudioSource jingleAudioSource = jingle.GetComponent<AudioSource>();

        switch (s)
        {
            case "objective":
                jingleAudioSource.clip = objective;
                    break;
            case "chargeOfEnergy":
                jingleAudioSource.clip = chargeOfEnergy;
                break;
            case "boost":
                jingleAudioSource.clip = boost;
                break;
            case "checkpoint":
                jingleAudioSource.clip = checkpoint;
                break;
        }

        jingleAudioSource.Play();
        Destroy(jingle, jingleAudioSource.clip.length);
    }
}