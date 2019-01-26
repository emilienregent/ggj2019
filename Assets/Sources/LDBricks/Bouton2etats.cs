using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bouton2etats : MonoBehaviour, IInteractable
{
    [SerializeField]
    private UnityEvent OnButtonOn;
    [SerializeField]
    private UnityEvent OnButtonOff;
    private bool ButtonOn = false;

    public void Interact()
    {
        if (ButtonOn)
        {
            OnButtonOff.Invoke();
        }
        else OnButtonOn.Invoke();
        ButtonOn = !ButtonOn;
    }

    public void DashIn()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ICharacter>() != null)
            collision.GetComponent<ICharacter>().InteractableList.Add(this);
    }
    private void OnTriggerExit(Collider2D collision)
    {
        if (collision.GetComponent<ICharacter>() != null)
            collision.GetComponent<ICharacter>().InteractableList.Remove(this);
    }
}
