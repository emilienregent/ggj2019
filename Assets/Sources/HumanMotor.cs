using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class HumanMotor : MonoBehaviour, ICharacter
{
    private Rigidbody2D rbody;

    [SerializeField] private float MoveMultiplier = .1f;
    [SerializeField] private float JumpForce;
    [SerializeField]
    public List<IInteractable> InteractableList { get; set; } = new List<IInteractable>();

    public bool _hasControl = true;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void TurnOffHumanControls()
    {
        _hasControl = false;
    }

    public bool Movement(float HorizontalMovement, float VerticalMovement)
    {
        if (_hasControl && Mathf.Abs(HorizontalMovement) > 0.2f)
        {
            float distance = MoveMultiplier * HorizontalMovement * Time.deltaTime;
            float direction = distance > 0 ? .6f : -.6f;

            Collider2D pushing = Physics2D.OverlapArea(
                new Vector2(transform.position.x + direction, transform.position.y + .9f), 
                new Vector2(transform.position.x + direction + distance, transform.position.y - .9f),
                ~LayerMask.GetMask("Players")
            );

            if (!pushing || pushing.isTrigger == true)
            {
                rbody.transform.Translate(new Vector3(MoveMultiplier * HorizontalMovement, rbody.velocity.y * Time.deltaTime, 0f));
            }

            return true;
        }

        return false;
    }

    public void Jump()
    {
        if (!_hasControl)
            return;

        foreach (IInteractable JumpInteract in InteractableList)
        {
            if (JumpInteract.JumpOn(this))
            {
                return;
            }
        }
        if (IsGrounded())
        {
            rbody.AddForce(new Vector2(0f,JumpForce));
        }
    }

    private bool IsGrounded()
    {
        bool grounded = Physics2D.OverlapArea(
                new Vector2(transform.position.x - 0.5f, transform.position.y - 1f), 
                new Vector2(transform.position.x + 0.5f, transform.position.y - 1.1f),
                ~LayerMask.GetMask("Players")
            );
        return grounded;
    }

    public void Interact()
    {
        if (!_hasControl)
            return;

        foreach (IInteractable InteractWith in InteractableList)
        {
            InteractWith.Interact();
        }
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public void TransitionStart()
    {
        _hasControl = false;
        rbody.constraints = RigidbodyConstraints2D.FreezeAll;
        UnityEngine.Debug.Log("Transition Start " + _hasControl);
    }

    public void TransitionEnd()
    {
        //rbody.velocity = Vector2.zero;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        rbody.WakeUp();
        _hasControl = true;
        gameObject.SetActive(true);

        UnityEngine.Debug.Log("Transition End " + _hasControl);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(1, 0, 0, 0.5f);
    //    Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 1.075f), new Vector3(1, 0.05f,0));
    //}
}
