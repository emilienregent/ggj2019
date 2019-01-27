using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour
{
    public float distanceBeforeHumanStop = 4f;
    public float distanceBeforeOrcStop = 1f;
    public BoatController boatController = null;

    private PlayerController    _humanPlayerController = null;
    private PlayerController    _orcPlayerController = null;
    private GameCamera          _gameCamera = null;

    private float _initialHumanPosition = 0f;
    private float _initialOrcPosition = 0f;
    private int _stepCount = 0;

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
        _initialHumanPosition = Mathf.Abs(_humanPlayerController.playerCharacter.GetPosition().x);
        _initialOrcPosition = Mathf.Abs(_orcPlayerController.playerCharacter.GetPosition().x);
    }

    private void Update()
    {
        if (GameManager.gameState == GameState.INTRO)
        {
            float humanPositionX = Mathf.Abs(_humanPlayerController.playerCharacter.GetPosition().x);
            float orcPositionX = Mathf.Abs(_orcPlayerController.playerCharacter.GetPosition().x);

            if (_stepCount == (int)IntroState.HUMAN_ENTRANCE)
            {
                //Move Human into the screen
                if (humanPositionX - _initialHumanPosition < distanceBeforeHumanStop)
                {
                    bool isMoving = _humanPlayerController.playerCharacter.Movement(-1f, 0f);
                    _humanPlayerController.playerMotion.SetMovement(isMoving);
                    _humanPlayerController.playerMotion.SetDirection(false);
                }
                //Animate boat
                else
                {
                    MoveToNextStep();
                }
            }
            else if (_stepCount == (int)IntroState.ORC_ENTRANCE)
            {
                //Move Orc into the screen
                if (_initialOrcPosition - orcPositionX < distanceBeforeOrcStop)
                {
                    bool isMoving = _orcPlayerController.playerCharacter.Movement(0.5f, 1f);
                    _orcPlayerController.playerMotion.SetMovement(isMoving);
                    _orcPlayerController.playerMotion.SetDirection(true);
                }
                else
                {
                    MoveToNextStep();
                }
            }
        }
    }

    public void MoveToNextStep()
    {
        UnityEngine.Debug.Log("Move to next step " + _stepCount);
        switch(++_stepCount)
        {
            case (int)IntroState.BOAT_ENTRANCE:
                boatController.BindToIntro(this);
                boatController.StartIntro();

                _gameCamera.EnableBoundary(true);
                _humanPlayerController.playerMotion.SetMovement(false);
                break;
            case (int)IntroState.ORC_ENTRANCE:
                boatController.StopIntro();
                _gameCamera.EnableBoundary(false);
                ((OrcMotion)_orcPlayerController.playerMotion).GetComponent<SpriteRenderer>().sortingLayerName = "Orc";
                break;
            case (int)IntroState.END:
                _gameCamera.EnableBoundary(true);
                _orcPlayerController.playerMotion.SetMovement(false);
                StopIntro();
                break;
            default:
                MoveToNextStep();
                break;
        }

    }

    public void StopIntro()
    {
        GameManager.instance.StartGame();
    }
}