using UnityEngine;
using System.Collections;

public interface ICharacterMotion
{
    void SetMovement(bool isMoving);
    void SetDirection(bool isFacingRight);
}
