using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("P1_Action1"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
