using UnityEngine;

public class BlackHoleMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick _joystick;
    private Rigidbody _blackHoleRb;

    private void Start()
    {
        _blackHoleRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(_joystick.Direction);
    }

    private void Move(Vector2 direction)
    {
        _blackHoleRb.AddForce(new Vector3(direction.x, 0, direction.y) * speed, ForceMode.VelocityChange);
    }
}
