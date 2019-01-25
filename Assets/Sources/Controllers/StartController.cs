using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    private int _playerCount = 0;
    public List<PlayerController> players;

    // Start is called before the first frame update
    private void Start()
    {
        // Detect players plugged. Then increment _playerCount accordingly
        for (int i = 0; i < Input.GetJoystickNames().Length; ++i)
        {
            if (Input.GetJoystickNames()[i] != string.Empty)
            {
                AssignToPlayer(i);
            }
            else
            {
                UnityEngine.Debug.Log("Joystick '" + i + "' is invalid and can't be use for players");
            }

            if (_playerCount >= players.Count)
            {
                break;
            }
        }
    }

    private void AssignToPlayer(int index)
    {
        UnityEngine.Debug.Log("Assign Joystick '" + Input.GetJoystickNames()[index] + "' to player " + (index + 1));

        PlayerController player = players[_playerCount];
        player.AssignGamepad(index);

        _playerCount++;
    }

    private void Update()
    {
        if (GameManager.gameState == GameState.INITIALIZED && GetPlayerReadyCount() == players.Count)
        {
            GameManager.instance.Start();
        }
    }

    private int GetPlayerReadyCount()
    {
        int playerCount = players.Count;
        int playerReadyCount = 0;

        for (int i = 0; i < playerCount; ++i)
        {
            if (players[i].playerState == PlayerState.READY)
            {
                playerReadyCount++;
            }
        }

        return playerReadyCount;
    }
}
