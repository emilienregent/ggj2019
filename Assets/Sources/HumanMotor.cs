using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class HumanMotor : MonoBehaviour
{
    private Rigidbody2D rbody;
    [SerializeField]
    private float JumpForce;
    private IInteractable CanInteractWith;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

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

    public void Movement(float HorizontalMovement, float VerticalMovement)
    {
        rbody.AddForce(new Vector2(HorizontalMovement, 0));
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rbody.AddForce(new Vector2(0,JumpForce));
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.5f);
        if (hit)
        {
            return true;
        }
        return false;

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
