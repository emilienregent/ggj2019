﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private int _index = 0;
    private PlayerState _playerState = default(PlayerState);
    private GamepadState _gamepadState = default(GamepadState);

    public int index { get { return _index; } }
    public PlayerState playerState { get { return _playerState; } }
    public GamepadState gamepadState { get { return _gamepadState; } }

    private ICharacter _playerCharacter;
    private ICharacterMotion _playerMotion;

    public ICharacter playerCharacter { get { return _playerCharacter; } }
    public ICharacterMotion playerMotion { get { return _playerMotion; } }

    public bool isWalkingIn = false;
    private readonly float _walkingTimeMax = .5f;
    public float walkingTime = 0f;
    public Rigidbody2D rbody = null;

    private void Awake()
    {
        _playerCharacter = GetComponentInChildren<ICharacter>();
        _playerMotion = GetComponentInChildren<ICharacterMotion>();
        rbody = GetComponentInChildren<Rigidbody2D>();
    }

    public void AssignGamepad(int index, bool isGamepad)
    {
        _index = index + 1;
        _gamepadState = isGamepad ? GamepadState.GAMEPAD_PLUGGED : GamepadState.KEYBOARD;
        _playerState = PlayerState.INITIALIZED;
    }

    private void Update()
    {
        if (_gamepadState == GamepadState.GAMEPAD_PLUGGED || _gamepadState == GamepadState.KEYBOARD)
        {
            if (_playerState == PlayerState.INITIALIZED && IsPressedAction(Button.BUTTON_A))
            {
                _playerState = PlayerState.READY;

                //TODO: Display player ready state (sound/image)
            }

            if (_playerState == PlayerState.READY && IsPressedAction(Button.BUTTON_B))
            {
                _playerState = PlayerState.INITIALIZED;

                //TODO: Display player ready state (sound/image)
            }
        }

        if (isWalkingIn)
        {
            if (walkingTime < _walkingTimeMax)
            {
                playerMotion.SetMovement(playerCharacter.Movement(.75f, 0f));
                playerMotion.SetDirection(true);
                walkingTime += Time.deltaTime;
            }
            else
            {
                isWalkingIn = false;
            }
        }
        else if (GameManager.gameState == GameState.RUNNING)
        {
            float horizontal = _gamepadState == GamepadState.GAMEPAD_PLUGGED 
                ? Input.GetAxis("P" + _index + "_Horizontal")
                : Input.GetAxis("P" + _index + "_Horizontal_Keyboard");

            float vertical = _gamepadState == GamepadState.GAMEPAD_PLUGGED
                ? Input.GetAxis("P" + _index + "_Vertical")
                : Input.GetAxis("P" + _index + "_Vertical_Keyboard");

            bool isMoving = _playerCharacter.Movement(horizontal, vertical);

            _playerMotion.SetMovement(isMoving);

            if (isMoving == true)
            {
                _playerMotion.SetDirection(horizontal >= 0f);
            }

            if (IsPressedAction(Button.BUTTON_A))
            {
                _playerCharacter.Jump();

                _playerMotion.DoJump();
            }

            if (IsPressedAction(Button.BUTTON_X))
            {
                _playerCharacter.Interact();
            }
        }
    }

    // Check button pressed (1=A, 2=B, 3=X, 4=Y)
    private bool IsPressedAction(Button button)
    {
        string actionName = "P" + _index + "_Action" + (int)button;
        bool isPressed = Input.GetButtonDown(actionName);

        if (isPressed == true)
        {
            Debug.Log(actionName + " is pressed ");
        }

        return isPressed;
    }
}
