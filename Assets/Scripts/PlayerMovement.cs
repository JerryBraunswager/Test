using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField] private FixedJoystick _joystick;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_joystick.Vertical == 0 & _joystick.Horizontal == 0)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            Vector3 direction = Vector3.up * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
            _rigidbody.velocity = direction * _speed * Time.fixedDeltaTime;
        }
    }
}
