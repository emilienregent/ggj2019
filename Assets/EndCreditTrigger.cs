using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<OrcaMotor>() != null)
        {
            SceneManager.LoadScene("End");
        }
    }
}
