using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stinger : MonoBehaviour
{
    bool StingerPlayed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.GetComponent<OrcaMotor>() == null & StingerPlayed == false)
        {
            return;
        }
        GetComponent<AudioSource>().Play();
        StingerPlayed = true;
    }
}
