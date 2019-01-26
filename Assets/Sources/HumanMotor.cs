using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class HumanMotor : MonoBehaviour, ICharacter
{
    private Rigidbody2D rbody;
    [SerializeField] private float MoveForce;
    [SerializeField] private float JumpForce;
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
        Vector2 force = new Vector2(HorizontalMovement, 0f) * MoveForce;

        rbody.AddForce(force);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rbody.AddForce(new Vector2(0f,JumpForce));
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 1.1f);

        if (hit)
        {
            return true;
        }

        return false;

    }
    public void Interact()
    {
        Debug.Log("Human Interact Attempt");
        if (CanInteractWith == null)
        {
            Debug.Log("no interactable nearby");
            return;
        }
        CanInteractWith.Interact();
    }
}
