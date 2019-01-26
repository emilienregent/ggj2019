using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private CameraAnchor[] _anchors = { };
    private CameraAnchor _currentAnchor = null;
    private Vector3 _startPosition = Vector3.zero;
    private Vector3 _currentVelocity = Vector3.zero;
    private int _currentIndex = 0;
    private float _currentMovementTime = 0f;
    private bool _isMoving = false;

    public float movementTime = 3f;

    private void Start()
    {
        GameObject[] anchorGameObjects = GameObject.FindGameObjectsWithTag("CameraAnchor");
        _anchors = new CameraAnchor[anchorGameObjects.Length];

        for (int i = 0; i < anchorGameObjects.Length; ++i)
            _anchors[i] = anchorGameObjects[i].GetComponent<CameraAnchor>();

        _startPosition = transform.position;           
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.Slerp(
                _startPosition, 
                _currentAnchor.transform.position, 
                Mathf.SmoothStep(0f, 1f, _currentMovementTime / movementTime)
            );

            _currentMovementTime += Time.deltaTime;
            _isMoving &= _currentMovementTime < movementTime;

            if (!_isMoving)
                _currentAnchor.OnCameraReach.Invoke();
        }
    }

    public void MoveToNextAnchor()
    {
        _currentIndex++;

        for (int i = 0; i < _anchors.Length; ++i)
        {
            if (_anchors[i].index == _currentIndex)
            {
                _currentAnchor = _anchors[i];
                _currentMovementTime = 0f;
                _startPosition = transform.position;
                _isMoving = true;
            }
        }
    }
}
