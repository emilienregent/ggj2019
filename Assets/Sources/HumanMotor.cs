using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class HumanMotor : MonoBehaviour, ICharacter
{
    private Rigidbody2D rbody;
    [SerializeField]
    private float JumpForce;
    public List<IInteractable> InteractableList { get; set; }

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.55f);
        if (hit)
        {
            return true;
        }
        return false;

    }
    public void Interact()
    {
        foreach (IInteractable InteractWith in InteractableList)
        {
            InteractWith.Interact();
        }
    }
}
