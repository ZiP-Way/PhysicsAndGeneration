using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _sensetivity;
    [SerializeField] private Joystick _joystick;

    private Quaternion _originRotation;
    private float _angleHorizontal;
    private float _angleVertical;

    private void Start()
    {
        _originRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        _angleHorizontal += _joystick.Horizontal * _sensetivity;
        _angleVertical += _joystick.Vertical * _sensetivity;

        _angleVertical = Mathf.Clamp(_angleVertical, -60, 60);

        Quaternion rotationY = Quaternion.AngleAxis(_angleHorizontal, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(-_angleVertical, Vector3.right);

        transform.rotation = _originRotation * rotationY * rotationX;
    }
}
