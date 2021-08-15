using System.Collections;
using System.Collections.Generic;
using ThreeDeePlatformerTest.Scripts;
using UnityEngine;

namespace ThreeDeePlatformerTest.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform groundCheckTransform;
        [SerializeField] private LayerMask _playerMask;

        private Rigidbody _player;

        private bool _isGrounded;

        private bool _jumpButtonPressed;
        private float _horizontalInput;
        private bool _doubleJumpAvailable;

        private Vector3 _gravity = new Vector3(0f, -9.81f, 0f);

        // Start is called before the first frame update
        void Start()
        {
            _player = GetComponent<Rigidbody>();
            _isGrounded = true;
        }

        // Update is called once per frame
        void Update()
        {
            SetGravity();
            if (GameOverScript.IsGameOver)
            {
                _horizontalInput = 0f;
                _player.velocity = Vector3.zero;
                return;
            }

            if (Input.GetButtonDown("Jump"))
            {
                _jumpButtonPressed = true;
            }

            _horizontalInput = Input.GetAxis("Horizontal") * 2.7f;
        }

        void FixedUpdate()
        {
            _isGrounded = Physics.OverlapSphere(groundCheckTransform.position, 0.1f, _playerMask).Length != 0;
            Jump();

            _player.velocity = new Vector3(_horizontalInput, _player.velocity.y, _player.velocity.z);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                Score.ScoreValue += 10;
                Destroy(other.gameObject);
            }
        }

        private void SetGravity()
        {
            if (GameOverScript.IsGameOver)
            {
                Physics.gravity = Vector3.zero;
                return;
            }
            Physics.gravity = _gravity;
        }

        private void Jump()
        {
            if (_jumpButtonPressed && (_isGrounded || _doubleJumpAvailable))
            {
                if (!_isGrounded)
                {
                    _doubleJumpAvailable = false;
                }
                _player.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
                _jumpButtonPressed = !_jumpButtonPressed;
            }

            if (_isGrounded)
            {
                _doubleJumpAvailable = true;
            }
        }
    }
}