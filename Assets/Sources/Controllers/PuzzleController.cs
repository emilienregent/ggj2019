using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    private GameCamera _gameCamera = null;

    [SerializeField]
    private Transform _humanSpawn = null;

    private GameObject _human = null;
    private Collider2D _collider = null;

    private void Awake()
    {
        _human = GameObject.FindWithTag("HumanBody");
        _gameCamera = Camera.main.GetComponent<GameCamera>();
        _collider = GetComponent<Collider2D>();

        UnityEngine.Assertions.Assert.IsNotNull(_human, "Can't find a HUMAN player.");
        UnityEngine.Assertions.Assert.IsNotNull(_gameCamera, "Can't find a GameCamera behavior on main camera.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ICharacter>() != null)
            _gameCamera.MoveToNextAnchor();

        _collider.enabled = false;
    }

    public void SetupPuzzle()
    {
        _human.transform.position = _humanSpawn.position;
    }
}
