using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAudioPlay : MonoBehaviour
{
    AudioSource _AudioSource;
    public AudioClip Plouf;
    public AudioClip Movement;
    public AudioClip Horn;
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    void PlayPlouf()
    {
        _AudioSource.clip = Plouf;
        _AudioSource.Play();
    }
    void PlayMovement()
    {
        _AudioSource.clip = Movement;
        _AudioSource.Play();
    }
    void PlayHorn()
    {
        _AudioSource.clip = Horn;
        _AudioSource.Play();
    }
}
