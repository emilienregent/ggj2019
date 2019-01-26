using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartView : MonoBehaviour
{
    public GameObject overlay = null;

    private void Update()
    {
        if (overlay.activeSelf == true && GameManager.gameState == GameState.RUNNING)
        {
            overlay.SetActive(false);
        }
        else if (overlay.activeSelf == false && GameManager.gameState != GameState.RUNNING)
        {
            overlay.SetActive(true);
        }
    }
}
