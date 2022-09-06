using System;
using System.Collections;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class ColliderDetectionController : MonoBehaviour
    {
        [Inject] private Player _player;

        [SerializeField] private GroundDetectorController _wallDetector;
        [SerializeField] private GroundDetectorController _groundDetector;
        [SerializeField] private GroundDetectorController _groundCheck;
        
        private Rigidbody2D _rigidbody;
        private bool _canJump; 
        private bool _isFalling;
        private float _lastY;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _lastY = gameObject.transform.position.y;
            _player.Input.PlayerInput.Jump.started += JumpOnStarted;
        }

        private void Update()
        {
            LogicUpdate();
            
            DataUpdate();
        }

        private void FixedUpdate()  
        {
            var position = gameObject.transform.position;
            _isFalling = position.y < _lastY && Math.Abs(position.y - _lastY) > _player.FallingStepValue;
            _lastY = position.y;
        }

        private void OnDisable()
        {
            _player.Input.PlayerInput.Jump.started -= JumpOnStarted;
        }

        private void DataUpdate()
        {
            _player.CanJump = _canJump;
            _player.IsFalling = _isFalling;
        }

        private void LogicUpdate()
        {
            if (_groundCheck.Value == true && _groundDetector.Value == true)
            {
                _canJump = true;
            }
            else if (!_wallDetector.Value && _groundDetector.Value)
            {
                _canJump = true;
            }
            else if (_groundCheck.Value)
            {
                _canJump = true;
            }
            else
            {
                StartCoroutine(StartCoyoteTime());
            }
        }

        private void JumpOnStarted(InputAction.CallbackContext obj)
        {
            _player.CanCoyoteJump = true;
            StartCoroutine(StartJumpCoyoteTime());
        }
        
        private IEnumerator StartCoyoteTime()
        {
            yield return new WaitForSeconds(_player.CoyoteTime);
            _canJump = false;
        }
        
        private IEnumerator StartJumpCoyoteTime()
        {
            yield return new WaitForSeconds(_player.CoyoteTime);
            _player.CanCoyoteJump = false;
        }
    }
}
