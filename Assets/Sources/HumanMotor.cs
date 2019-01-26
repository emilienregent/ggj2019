using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class HumanMotor : MonoBehaviour, ICharacter
{
    private Rigidbody2D rbody;

    [SerializeField] private float MoveForce;
    [SerializeField] private float JumpForce;
    [SerializeField]
    public List<IInteractable> InteractableList { get; set; } = new List<IInteractable>();

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
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
        bool grounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 1.05f), new Vector2(transform.position.x + 0.5f, transform.position.y - 1.1f));
        return grounded;
    }
    public void Interact()
    {
        foreach (IInteractable InteractWith in InteractableList)
        {
            InteractWith.Interact();
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(1, 0, 0, 0.5f);
    //    Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 1.075f), new Vector3(1, 0.05f,0));
    //}
}
