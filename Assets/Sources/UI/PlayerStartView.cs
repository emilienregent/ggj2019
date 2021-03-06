﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStartView : MonoBehaviour
{
    private const string PLAYER_NOT_READY_TEXT = "PLAYER {0} - PRESS {1}";
    private const string PLAYER_READY_TEXT = "PLAYER {0} - READY";
    private const string PLAYER_READY_BUTTON = "A";
    private const string PLAYER_READY_KEY_ONE = "A";
    private const string PLAYER_READY_KEY_TWO = "O";

    [SerializeField] private Text _text = null;
    [SerializeField] private Image _image = null;
    [SerializeField] private PlayerTag _tag = default(PlayerTag);
    private PlayerController _player = null;
    private Animator _textAnimator = null;

    private void Awake()
    {
        GameObject playerGameObject = GameObject.FindWithTag(_tag.ToString());

        UnityEngine.Assertions.Assert.IsNotNull(playerGameObject, "Can't find a player gameobject with " + _tag.ToString().ToLower());

        _player = playerGameObject.GetComponent<PlayerController>();
        _textAnimator = _text.GetComponent<Animator>();

        UnityEngine.Assertions.Assert.IsNotNull(_player, "Can't find a PlayerController attached");
    }

    private void Update()
    {
        if (GameManager.gameState != GameState.INTRO && GameManager.gameState != GameState.RUNNING)
        {
            string input = _player.gamepadState == GamepadState.GAMEPAD_PLUGGED
                                  ? PLAYER_READY_BUTTON
                                  : _player.index == 1 ? PLAYER_READY_KEY_ONE : PLAYER_READY_KEY_TWO;
            
            _text.text = _player.playerState == PlayerState.READY
                ? string.Format(PLAYER_READY_TEXT, _player.index)
                : string.Format(PLAYER_NOT_READY_TEXT, _player.index, input);

            _textAnimator.SetBool("Blink", _player.playerState != PlayerState.READY);
        }
        else if (_text.enabled == true)
        {
            _text.enabled = false;
            _image.enabled = false;
        }
    }
}
