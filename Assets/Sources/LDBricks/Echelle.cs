using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echelle : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject TeleportPoint;

    public void Interact()
    {

    }

    public void DashIn()
    {

    }

    public bool JumpOn(HumanMotor Human)
    {
        Human.transform.position = TeleportPoint.transform.position;
        return true;
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
