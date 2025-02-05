using NUnit.Framework.Constraints;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator[] _dronFansAnimator;
    [SerializeField] private Animator _dronAnimator;
    [SerializeField] private CinemachineCamera _camera;
    [SerializeField] private CameraTarget _targetNull;
    [SerializeField] private CameraTarget _targetSelf;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxSpeed;
    private Rigidbody _rb;
    private PlayerMov _input;
    private Quaternion _rotation;

    void Start()
    {
        _input = new PlayerMov();
        _input.Enable();
        _rb = GetComponent<Rigidbody>();
        _rotation = transform.rotation;
    }


    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (_rb.linearVelocity.magnitude > _maxSpeed)
        {
            _rb.linearVelocity = _rb.linearVelocity.normalized * _maxSpeed;
        }

        if (_input.Player.Moveforward.IsPressed())
        {
            _rb.AddForce(transform.forward * _speed, ForceMode.VelocityChange);
        }

        if (_input.Player.Moveleft.IsPressed())
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, -90, 0), _rotationSpeed * Time.deltaTime);
        }

        if (_input.Player.Moveright.IsPressed())
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, 90, 0), _rotationSpeed * Time.deltaTime);
        }

        if (_input.Player.Moveback.IsPressed())
        {
            _rb.AddForce(-transform.forward * _speed, ForceMode.VelocityChange);
        }

        if (_input.Player.Moveup.IsPressed())
        {
            _rb.AddForce(Vector3.up * _speed, ForceMode.VelocityChange);
        }

        if (_input.Player.Movedown.IsPressed())
        {
            _rb.AddForce(Vector3.down * _speed, ForceMode.VelocityChange);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            for (int i = 0; i < _dronFansAnimator.Length; i++)
            {
                _dronFansAnimator[i].SetBool("IsGrounded", true);
            }
        }

        if (collision.gameObject.layer == 8)
        {
            _camera.Target = _targetNull;
            _dronAnimator.enabled = true;
            _dronAnimator.SetBool("IsTooHigh", true);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            for (int i = 0; i < _dronFansAnimator.Length; i++)
            {
                _dronFansAnimator[i].SetBool("IsGrounded", false);
            }
        }

        if (collision.gameObject.layer == 8)
        {
            _camera.Target = _targetSelf;
            _dronAnimator.SetBool("IsTooHigh", false);
            _dronAnimator.enabled = false;
            transform.rotation = _rotation;

        }
    }
}
