using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    public int index = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, .5f);
    }
}
