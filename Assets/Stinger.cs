using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stinger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.GetComponent<OrcaMotor>() == null)
        {
            return;
        }
        GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }
}
