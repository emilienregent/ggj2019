using UnityEngine;
using UnityEngine.Events;

public class CameraAnchor : MonoBehaviour
{
    public int index = 1;
    public UnityEvent OnCameraReach;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, .5f);
    }
}
