using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping = 1f;
    private Transform _cameraTr;

    private void Start()
    {
        _cameraTr = transform;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        var currentPosition = _cameraTr.position;
        var desiredPosition = target.position + (target.rotation * offset);
        _cameraTr.position = Vector3.Lerp(currentPosition, desiredPosition, Time.deltaTime * damping);
    }
}
