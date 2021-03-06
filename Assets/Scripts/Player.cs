using ThreeDeePlatformerTest.Scripts.TempSettings;
using UnityEngine;

namespace ThreeDeePlatformerTest.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform groundCheckTransform;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private LayerMask _playerMask;
        [SerializeField] private LayerMask _doorMask;
        [SerializeField] private float jumpStrength;

        private Rigidbody _player;
        private Transform _playerTransform;
        private Animator animator;

        private bool _isGrounded;
        private bool _isInDoorMask;

        private bool _jumpButtonPressed;
        private float _horizontalInput;
        private bool _doubleJumpAvailable;

        private Vector3 _gravity = new Vector3(0f, -9.81f, 0f);

        // Start is called before the first frame update
        void Start()
        {
            _player = GetComponent<Rigidbody>();
            _playerTransform = GetComponent<Transform>();
            animator = GetComponent<Animator>();
            if (PlayerSettings.PlayerStartPosition.HasValue)
            {
                GetComponent<Transform>().position = PlayerSettings.PlayerStartPosition.Value;
            }
            _isGrounded = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (ScreenScript.IsPaused)
            {
                return;
            }
            SetGravity();
            if (ScreenScript.IsGameOver)
            {
                _horizontalInput = 0f;
                _player.velocity = Vector3.zero;
                return;
            }

            if (Input.GetButtonDown("Jump") && !_isInDoorMask)
            {
                _jumpButtonPressed = true;
            }

            _horizontalInput = Input.GetAxis("Horizontal") * 2.7f;

            TurnTransforms();

            SetAnimations();
        }

        private void SetAnimations()
        {
            if (_horizontalInput == 0)
            {
                animator.SetBool("run", false);
            }
            else
            {
                animator.SetBool("run", true);
            }
        }

        private void TurnTransforms()
        {
            if (_horizontalInput > 0)
            {
                _playerTransform.transform.forward = new Vector3(90, 0, 0);
            }

            if (_horizontalInput < 0)
            {
                _playerTransform.transform.forward = new Vector3(-90, 0, 0);
            }
            cameraTransform.transform.position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, -7f);
        }

        void FixedUpdate()
        {
            if (ScreenScript.IsPaused)
            {
                return;
            }
            _isInDoorMask = Physics.OverlapSphere(groundCheckTransform.position, 0.1f, _doorMask).Length != 0;
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
            if (ScreenScript.IsGameOver)
            {
                Physics.gravity = Vector3.zero;
                
                return;
            }
            Physics.gravity = _gravity;
        }

        private void Jump()
        {
            if (_isInDoorMask)
            {
                return;
            }

            if (_jumpButtonPressed && (_isGrounded || _doubleJumpAvailable))
            {
                var velocity = _player.velocity;
                var jumpVector3 = new Vector3(0, jumpStrength, 0);
                if (!_isGrounded)
                {
                    _doubleJumpAvailable = false;
                     jumpVector3 = new Vector3(0, jumpStrength - (_player.velocity.y * 0.8f), 0);
                }

                _player.AddForce(jumpVector3, ForceMode.Impulse);
                _jumpButtonPressed = !_jumpButtonPressed;
            }

            if (_isGrounded)
            {
                _doubleJumpAvailable = true;
            }
        }
    }
}