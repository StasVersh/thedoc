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
        private float _lastY;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _lastY = gameObject.transform.position.y;
        }

        private void Update()
        {
            LogicUpdate();
            
            DataUpdate();
        }

        private void DataUpdate()
        {
            _player.CanJump = _canJump;
            _player.IsFalling = _isFalling;
            if (_canJump)
            {
                StartCoroutine(DashRollback());
            }
        }

        private IEnumerator DashRollback()
        {
            yield return new WaitForSeconds(_player.DashRollback);
            _player.CanDash = true;
            _player.CanDoubleJump = true;
        }

        private void LogicUpdate()
        {
            var position = gameObject.transform.position;
            if (_rigidbody.velocity.y >= 0)
            {
                _isFalling = false;
            }
            else
            {
                _isFalling = position.y < _lastY && Math.Abs(position.y - _lastY) > _player.FallingStepValue;
            }
            _lastY = position.y;
            
            if (_groundCheck.Value && _groundDetector.Value)
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
                _canJump = false;
            }
        }
    }
}
