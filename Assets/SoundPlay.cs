using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    AudioSource _AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip Clip)
    {
        _AudioSource.clip = Clip;
        _AudioSource.Play();
    }
}
