using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableWithEvent : MonoBehaviour, IInteractable
{
    [SerializeField]
    private UnityEvent OnInteract;
    [SerializeField]
    private UnityEvent OnDash;

    public void Interact()
    {
        OnInteract.Invoke();
    }

    public void DashIn()
    {
        OnDash.Invoke();
    }
}
