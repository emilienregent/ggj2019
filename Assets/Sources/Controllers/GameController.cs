using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private float _elapsedTime = 0f;

    private void Awake()
    {
        //TODO: Initialize game data here

        GameManager.instance.Initialize();
    }

    private void Update()
    {
        if (GameManager.instance.isReady == true)
        {
            // Each second
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= 1f)
            {
                _elapsedTime = _elapsedTime % 1f;

                GameManager.instance.UpdateTimer();
            }
        }
    }

    private void OnTimerEnded(object sender, int elapsedTime)
    {
        UnityEngine.Debug.Log("Game ended.");
    }

    private void OnDestroy()
    {
        GameManager.Destroy();
    }
}