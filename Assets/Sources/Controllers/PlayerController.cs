using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private int _index = 0;
    private PlayerState _playerState = default(PlayerState);
    private GamepadState _gamepadState = default(GamepadState);

    public int index { get { return _index; } }
    public PlayerState playerState { get { return _playerState; } }
    public GamepadState gamepadState { get { return _gamepadState; } }

    private ICharacter PlayerCharacter;
    private ICharacterMotion PlayerMotion;

    private void Start()
    {
        PlayerCharacter = GetComponentInChildren<ICharacter>();
        PlayerMotion = GetComponentInChildren<ICharacterMotion>();
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

        if (GameManager.gameState == GameState.RUNNING)
        {
            float horizontal = _gamepadState == GamepadState.GAMEPAD_PLUGGED 
                ? Input.GetAxis("P" + _index + "_Horizontal")
                : Input.GetAxis("P" + _index + "_Horizontal_Keyboard");

            float vertical = _gamepadState == GamepadState.GAMEPAD_PLUGGED
                ? Input.GetAxis("P" + _index + "_Vertical")
                : Input.GetAxis("P" + _index + "_Vertical_Keyboard");

            bool isMoving = PlayerCharacter.Movement(horizontal, vertical);

            PlayerMotion.SetMovement(isMoving);

            if (isMoving == true)
            {
                PlayerMotion.SetDirection(horizontal >= 0f);
            }

            if (IsPressedAction(Button.BUTTON_A))
            {
                PlayerCharacter.Jump();
            }

            if (IsPressedAction(Button.BUTTON_X))
            {
                PlayerCharacter.Interact();
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
