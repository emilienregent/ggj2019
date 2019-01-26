using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class OrcaMotor : MonoBehaviour, ICharacter
{
    private Rigidbody2D rbody;
    private IInteractable CanDashIn;
    private float DashButtonSpeed = 0.3f;
    [SerializeField]
    private float DashForce;
    private bool IsFacingRight;
    private float DashInteractTime;
    public List<GameObject> WaterVolumes;
    public List<GameObject> InteractableList { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CanDashIn = collision.transform.GetComponent<IInteractable>();
        if (DashInteractTime >= Time.time)
        {
            if (CanDashIn != null)
            {
                CanDashIn.DashIn();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (CanDashIn == collision.transform.GetComponent<IInteractable>())
        {
            CanDashIn = null;
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
        rbody.AddForce(new Vector2(HorizontalMovement, VerticalMovement));
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
            rbody.AddForce(new Vector2(DashForce, 0));
        }
        else rbody.AddForce(new Vector2(-DashForce, 0));
    }

    public void Interact()
    {

        foreach(GameObject InteractWith in InteractableList)
        {
            IInteractable InteractWithComponent = InteractWith.GetComponent<IInteractable>();
            InteractWithComponent.Interact();
        }
    }
}

