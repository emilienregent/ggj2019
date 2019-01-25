using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableWithEvent : MonoBehaviour, IInteractable
{
    [SerializeField]
    private UnityEvent OnInteract;

    public void Interact()
    {
        OnInteract.Invoke();
    }
}
