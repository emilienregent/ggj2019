using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour
{
    private IntroController _introController = null;

    public void BindToIntro(IntroController intro)
    {
        _introController = intro;
    }

    public void StartIntro()
    {
        gameObject.SetActive(true);
    }

    public void StopIntro()
    {
        gameObject.SetActive(false);
    }

    public void AnimationEnded()
    {
        _introController.MoveToNextStep();
    }
}
