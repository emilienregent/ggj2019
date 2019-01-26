using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleOrcSaut : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<OrcaMotor>() != null)
        {
            if (other.GetComponent<Rigidbody2D>().gravityScale == 1)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
