using System;
using System.Collections;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
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
        private Vector2 _velocity;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            LogicUpdate();

            _velocity = _rigidbody.velocity;
            
            DataUpdate();
        }

        private void FixedUpdate()  
        {
            _isFalling = _velocity.y < 0;
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
        
        private IEnumerator StartCoyoteTime()
        {
            yield return new WaitForSeconds(_player.CoyoteTime);
            _canJump = false;
        }
    }
}
