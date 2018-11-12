using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {

    private Rigidbody _rigidBody;

    [SerializeField]
    [Range(2, 10)]
    private float _topSpeed = 4f;
    [SerializeField]
    [Range(2, 5)]
    private float _accelerationSpeed = 2f;
    private float _currentSpeed = 0f;

    [SerializeField]
    [Range(2, 8)]
    private float _topTurnSpeed = 2f;
    private float _currentRotationSpeed = 0f;

    [SerializeField]
    [Range(100, 1000)]
    private float _jumpForce = 100f;
    private float _jump;

    [SerializeField]
    private KeyCode _forwardKey;
    [SerializeField]
    private KeyCode _backwardKey;
    [SerializeField]
    private KeyCode _leftKey;
    [SerializeField]
    private KeyCode _rightKey;
    [SerializeField]
    private KeyCode _jumpKey;

    private bool _canJump = true;

    //
    public Transform player;
    public bool active;

    private void Start() {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        //Debug.Log(distanceToPlayer);
        if (Input.GetKeyDown("[7]"))
        {
            active = !active;
        }

        if (active)
        {
            // forward
            if (Input.GetKey(_forwardKey))
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, -_topSpeed, _accelerationSpeed * Time.deltaTime);
            }
            // backward
            else if (Input.GetKey(_backwardKey))
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, _topSpeed, _accelerationSpeed * Time.deltaTime);
            }
            else
            {
                _currentSpeed = Mathf.Lerp(_currentSpeed, 0, (_accelerationSpeed * Time.deltaTime) * 1.8f);
            }

            // rotate left
            if (Input.GetKey(_leftKey))
            {
                _currentRotationSpeed = Mathf.Lerp(_currentRotationSpeed, _topTurnSpeed, (_accelerationSpeed * Time.deltaTime) * 1.5f);
            }
            else if (Input.GetKey(_rightKey))
            {
                _currentRotationSpeed = Mathf.Lerp(_currentRotationSpeed, -_topTurnSpeed, (_accelerationSpeed * Time.deltaTime) * 1.5f);
            }
            else
            {
                _currentRotationSpeed = Mathf.Lerp(_currentRotationSpeed, 0f, (_accelerationSpeed * Time.deltaTime) * 1.8f);
            }
        }
        else
        {
            if(!active)
            {
                if(distanceToPlayer > 2)
                {
                    float speed = 5 * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
                    //transform.LookAt(player);
                }
                if (distanceToPlayer <= 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.position, 0);
                }
            }
        }
    }

    private void FixedUpdate() {

        // jump
        if (Input.GetKeyDown(_jumpKey) && _canJump) {
            _jump = _jumpForce;
        } else {
            _jump = 0f;
        }

        // apply movement
        transform.position += transform.forward * _currentSpeed * Time.fixedDeltaTime;

        // apply rotation
        transform.Rotate(new Vector3(_currentRotationSpeed, 0, 0));

        // jump
        _rigidBody.AddForce(-transform.right * _jump * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision other) {
        if (other.collider.tag.Equals("Ground")) {
            _canJump = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.collider.tag.Equals("Ground")) {
            _canJump = false;
        }
    }
}
