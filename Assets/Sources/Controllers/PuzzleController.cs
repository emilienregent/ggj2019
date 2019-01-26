using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    private GameCamera _gameCamera = null;

    [SerializeField]
    private Transform _humanSpawn = null;

    public GameObject _human = null;

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

    public void SetupPuzzle()
    {
        _human.transform.position = _humanSpawn.position;
    }
}
