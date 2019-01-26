using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private GameObject _topPart = null;

    [SerializeField]
    private Transform _topOpenTransform = null;

    private Vector3 _topClosedPos = Vector3.zero;

    [SerializeField]
    private GameObject _bottomPart = null;

    [SerializeField]
    private Transform _bottomOpenTransform = null;

    private Vector2 _bottomClosedPos = Vector2.zero;

    [SerializeField]
    private readonly float _openTime = 1.5f;

    private float _movePosition = 0f;
    private bool _isOpening = false;

    public void Start()
    {
        _topClosedPos = _topPart.transform.position;
        _bottomClosedPos = _bottomPart.transform.position;
    }

    public void Update()
    {
        if (_isOpening && _movePosition < _openTime)
            _movePosition += Time.deltaTime;
        else if (!_isOpening && _movePosition > 0f)
            _movePosition -= Time.deltaTime;
        else
            return;

        _topPart.transform.position = Vector3.Lerp(_topClosedPos, _topOpenTransform.position, _movePosition / _openTime);
        _bottomPart.transform.position = Vector3.Lerp(_bottomClosedPos, _bottomOpenTransform.position, _movePosition / _openTime);
    }

    public void Open()
    {
        _isOpening = true;
    }

    public void Close()
    {
        _isOpening = false;
    }
}
