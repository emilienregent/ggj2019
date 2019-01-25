using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaMotor : MonoBehaviour, ICharacter
{
    private Rigidbody2D rbody;
    private IInteractable CanInteractWith;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CanInteractWith = collision.transform.GetComponent<IInteractable>();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (CanInteractWith == collision.transform.GetComponent<IInteractable>())
        {
            CanInteractWith = null;
        }
    }

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void Movement(float HorizontalMovement, float VerticalMovement)
    {
        rbody.AddForce(new Vector2(HorizontalMovement, VerticalMovement));
    }

    public void Jump()
    {
        //nothing happens
    }

    public void Interact()
    {
        if (CanInteractWith == null)
        {
            Debug.Log("no interactable nearby");
            return;
        }
        CanInteractWith.Interact();
    }
}

