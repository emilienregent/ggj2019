using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class HumanMotion : MonoBehaviour, ICharacterMotion
{
    private const string IS_WALKING_KEY = "IsWalking";

    private Animator _animator = null;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovement(bool isMoving)
    {
        _animator.SetBool(IS_WALKING_KEY, isMoving);
    }

    public void SetDirection(bool isFacingRight)
    {
        transform.localScale = isFacingRight ? Vector2.right : Vector2.left;
    }
}
