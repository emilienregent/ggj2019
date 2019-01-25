using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private int _index = 0;
    private PlayerState _playerState = default(PlayerState);
    private GamepadState _gamepadState = default(GamepadState);

    public PlayerState playerState { get { return _playerState; } }
    public GamepadState gamepadState { get { return _gamepadState; } }

    public void AssignGamepad(int index)
    {
        _index = index + 1;
        _gamepadState = GamepadState.PLUGGED;
        _playerState = PlayerState.INITIALIZED;
    }

    private void Update()
    {
        if (_gamepadState == GamepadState.PLUGGED)
        {
            if (IsPressedAction(Button.BUTTON_A) && _playerState == PlayerState.INITIALIZED)
            {
                _playerState = PlayerState.READY;

                //TODO: Display player ready state (sound/image)
            }

            if (IsPressedAction(Button.BUTTON_B) && _playerState == PlayerState.READY)
            {
                _playerState = PlayerState.INITIALIZED;

                //TODO: Display player ready state (sound/image)
            }
        }
    }

    // Check button pressed (1=A, 2=B, 3=Y, 4=X)
    private bool IsPressedAction(Button button)
    {
        string actionName = "Action" + (int)button + "_P" + _index;
        bool isPressed = Input.GetButtonDown(actionName);

        if (isPressed == true)
        {
            UnityEngine.Debug.Log(actionName + " is pressed ");
        }

        return isPressed;
    }
}
