using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    bool Movement(float HorizontalMovement, float VerticalMovement);

    void Jump();

    void Interact();

    Vector2 GetPosition();

    List<IInteractable> InteractableList { get; set; }
}
