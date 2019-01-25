using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    void Movement(float HorizontalMovement, float VerticalMovement);

    void Jump();

    void Interact();
}
