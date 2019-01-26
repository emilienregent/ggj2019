using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleController : MonoBehaviour
{
    private GameCamera _gameCamera = null;

    private void Awake()
    {
        _gameCamera = Camera.main.GetComponent<GameCamera>();

        UnityEngine.Assertions.Assert.IsNotNull(_gameCamera, "Can't find a GameCamera behavior on main camera.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ICharacter>() != null)
            _gameCamera.MoveToNextAnchor();
    }
}
