using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class OrcaMotor : MonoBehaviour, ICharacter
{
    public Rigidbody2D rbody;
    private IInteractable CanDashIn;
    private float DashButtonSpeed = 0.3f;
    [SerializeField] private float MoveForce;
    [SerializeField] private float DashForce;
    [SerializeField]
    private float DashDelay;
    [SerializeField]
    public List<GameObject> WaterVolumes;
    public List<IInteractable> InteractableList { get; set; } = new List<IInteractable>();
    [SerializeField]
    private GameObject OrcVisual;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CanDashIn = collision.transform.GetComponent<IInteractable>();
        if (DashDelay >= Time.time)
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
            rbody.gravityScale = 1;
        }
        else rbody.gravityScale = 0;
    }

    public bool Movement(float HorizontalMovement, float VerticalMovement)
    {
        if (WaterVolumes.Count == 0)
        {
            return false;
        }

        Vector2 force = new Vector2(HorizontalMovement, VerticalMovement) * MoveForce;

        rbody.AddForce(force);
        OrcVisual.transform.eulerAngles = new Vector3(0,0,20 * VerticalMovement * -OrcVisual.transform.localScale.x);
        return Mathf.Approximately(HorizontalMovement, 0f) == false || Mathf.Approximately(VerticalMovement, 0f) == false;
    }

    public void Jump()
    {
        if (DashDelay >= Time.time)
        {
            return;
        }
        rbody.AddForce(new Vector2(DashForce * -OrcVisual.transform.localScale.x, 0f));
        DashDelay = Time.time + 0.3f;
    }

    public void Interact()
    {

        foreach(IInteractable InteractWith in InteractableList)
        {
            InteractWith.Interact();
        }
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}

