using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class OrcMotion : MonoBehaviour, ICharacterMotion
{
    private const string IS_MOVING_KEY = "IsMoving";

    private Animator _animator = null;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovement(bool isMoving)
    {
        _animator.SetBool(IS_MOVING_KEY, isMoving);
    }
}
