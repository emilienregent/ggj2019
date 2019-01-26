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

    public bool JumpOn(HumanMotor Human)
    {
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ICharacter>() != null)
            collision.GetComponent<ICharacter>().InteractableList.Add(this);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ICharacter>() != null)
            collision.GetComponent<ICharacter>().InteractableList.Remove(this);
    }

}
