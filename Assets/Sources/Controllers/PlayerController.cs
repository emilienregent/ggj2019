using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private int _index = 0;
    private PlayerState _playerState = default(PlayerState);
    private GamepadState _gamepadState = default(GamepadState);

    public PlayerState playerState { get { return _playerState; } }
    public GamepadState gamepadState { get { return _gamepadState; } }
    private ICharacter PlayerCharacter;

    public void AssignGamepad(int index, bool isGamepad)
    {
        _index = index + 1;
        _gamepadState = isGamepad ? GamepadState.GAMEPAD_PLUGGED : GamepadState.KEYBOARD;
        _playerState = PlayerState.INITIALIZED;
        PlayerCharacter = GetComponent<ICharacter>();
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
            if (IsPressedAction(Button.BUTTON_A))
            {
                PlayerCharacter.Jump();
            }
            if (IsPressedAction(Button.BUTTON_X))
            {
                PlayerCharacter.Interact();
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

            //TODO: Call Move on iCharacter with the horizontal and vertical
            PlayerCharacter.Movement(horizontal, vertical);
        }
    }

    // Check button pressed (1=A, 2=B, 3=Y, 4=X)
    private bool IsPressedAction(Button button)
    {
        string actionName = "P" + _index + "_Action" + (int)button;
        bool isPressed = Input.GetButtonDown(actionName);

        if (isPressed == true)
        {
            UnityEngine.Debug.Log(actionName + " is pressed ");
        }

        return isPressed;
    }
}
