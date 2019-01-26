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
                UnityEngine.Debug.Log("Assign Joystick '" + Input.GetJoystickNames()[i] + "' to player " + (i + 1));

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

        if (_playerCount < players.Count)
        {
            for (int i = _playerCount; i < players.Count; ++i)
            {
                UnityEngine.Debug.Log("Can't find a joystick for player " + (i + 1) + " assigning keyboard instead");

                AssignToPlayer(i, false);
            }
        }
    }

    private void AssignToPlayer(int index, bool isGamepad = true)
    {
        PlayerController player = players[_playerCount];

        player.AssignGamepad(index, isGamepad);

        _playerCount++;
    }

    private void Update()
    {
        if (GameManager.gameState == GameState.INITIALIZED && GetPlayerReadyCount() == players.Count)
        {
            GameManager.instance.StartGame();
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
