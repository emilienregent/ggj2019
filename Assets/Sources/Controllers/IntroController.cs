using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour
{
    public float distanceBeforeStop = 5f;
    public GameObject boat = null;

    private PlayerController    _humanPlayerController = null;
    private PlayerController    _orcPlayerController = null;
    private GameCamera _gameCamera = null;

    private float _initialPlayerPosition = 0f;

    private void Awake()
    {
        GameObject human = GameObject.FindWithTag(PlayerTag.HUMAN.ToString());
        GameObject orc = GameObject.FindWithTag(PlayerTag.ORC.ToString());

        _humanPlayerController = human.GetComponent<PlayerController>();
        _orcPlayerController = orc.GetComponent<PlayerController>();
        _gameCamera = Camera.main.GetComponent<GameCamera>();

        _gameCamera.EnableBoundary(false);
    }

    private void Start()
    {
        _initialPlayerPosition = Mathf.Abs(_humanPlayerController.playerCharacter.GetPosition().x);
    }

    private void Update()
    {
        if (GameManager.gameState == GameState.INTRO)
        {
            if (Mathf.Abs(_humanPlayerController.playerCharacter.GetPosition().x) > _initialPlayerPosition - distanceBeforeStop)
            {
                bool isMoving = _humanPlayerController.playerCharacter.Movement(1f, 0f);
                _humanPlayerController.playerMotion.SetMovement(isMoving);
            }
            else
            {
                MoveToNextStep();
            }
        }
    }

    public void MoveToNextStep()
    {
        boat.SetActive(true);
        _gameCamera.EnableBoundary(true);
        _humanPlayerController.playerMotion.SetMovement(false);
    }

    public void StopIntro()
    {
        GameManager.instance.StartGame();
    }
}