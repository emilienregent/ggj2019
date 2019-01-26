using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class OrcaMotor : MonoBehaviour, ICharacter
{
    private Rigidbody2D rbody;
    private IInteractable CanInteractWith;
    private float DashButtonSpeed = 0.3f;
    [SerializeField] private float MoveForce;
    [SerializeField] private float DashForce;
    private bool IsFacingRight;
    private float DashInteractTime;
    public List<GameObject> WaterVolumes;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CanInteractWith = collision.transform.GetComponent<IInteractable>();
        if (DashInteractTime >= Time.time)
        {
            if (CanInteractWith != null)
            {
                CanInteractWith.DashIn();
            }
        }
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
    private void Update()
    {
        if (WaterVolumes.Count == 0)
        {
            rbody.gravityScale = 0;
        }
        else rbody.gravityScale = 1;
    }

    public void Movement(float HorizontalMovement, float VerticalMovement)
    {
        if (WaterVolumes.Count == 0)
        {
            return;
        }

        Vector2 force = new Vector2(HorizontalMovement, VerticalMovement) * MoveForce;

        rbody.AddForce(force);

        if (HorizontalMovement > 0)
        {
            IsFacingRight = true;
        }
        else IsFacingRight = false;

        DashInteractTime = Time.time + 0.5f;
    }

    public void Jump()
    {
        if (IsFacingRight)
        {
            rbody.AddForce(new Vector2(DashForce, 0f));
        }
        else rbody.AddForce(new Vector2(-DashForce, 0f));
    }

    public void Interact()
    {

        if (CanInteractWith == null)
        {
            return;
        }
        CanInteractWith.Interact();
    }
}

