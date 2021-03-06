﻿using UnityEngine;
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
        float directionX = isFacingRight ? 1f : -1f;

        transform.localScale = new Vector2(directionX, 1f);
    }

    public void DoJump()
    {
        // Do Nothing Yet
    }
}
