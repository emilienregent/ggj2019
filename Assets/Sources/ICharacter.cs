using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    bool Movement(float HorizontalMovement, float VerticalMovement);

    void Jump();

    void Interact();

    List<IInteractable> InteractableList { get; set; }
}
