using System;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        [Inject] private Player _player;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        
        private void OnEnable()
        {
            _player.Controller = this;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            transform.localScale = _player.FaceDirection > 0 ? new Vector3(1, 1) : new Vector3(-1, 1);
        }

        private void Update()
        {
            var rigidbodyVelocity = _rigidbody.velocity;
            if (rigidbodyVelocity.y < -_player.MaxFallingSpeed)
            {
                rigidbodyVelocity.y = -_player.MaxFallingSpeed;
            }

            _rigidbody.velocity = rigidbodyVelocity;
        }

        public void Move(float speedValue, float direction)
        {
            if (direction != 0.0f)
            {
                transform.localScale = direction > 0 ? new Vector3(1, 1) : new Vector3(-1, 1);
                _player.FaceDirection = direction > 0 ? 1 : -1;
            }
            _rigidbody.velocity = new Vector2 (speedValue * direction, _rigidbody.velocity.y);
        }

        public void Jump(float speedValue)
        {
            if(_rigidbody == null) return;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, speedValue), ForceMode2D.Impulse);
        }

        public void StopJump()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }

        public void Hover(float forceValue, float maxSpeed)
        {
            _rigidbody.AddForce(new Vector2(0, forceValue), ForceMode2D.Force);
            var rigidbodyVelocity = _rigidbody.velocity;
            if (rigidbodyVelocity.y < -maxSpeed)
            {
                rigidbodyVelocity.y = -maxSpeed;
            }

            _rigidbody.velocity = rigidbodyVelocity;
        }

        public void DashingStart(float speed, float height)
        {
            var position = gameObject.transform.position;
            position = new Vector2(position.x, position.y + height);
            gameObject.transform.position = position;
            _rigidbody.velocity = new Vector2(speed * _player.FaceDirection, 0);
        }

        public void DashingBrake(float speed)
        {
            _rigidbody.AddForce(new Vector2(speed * -_player.FaceDirection, 0));
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }

        public bool DashEnding()
        {
            return Math.Abs(_rigidbody.velocity.x) <= _player.Speed;
        }

        public void Reset()
        {
            _rigidbody.velocity = Vector2.zero;
        }

        public void ResetY()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }

        public void SetAnimation(string animationName)
        {
            _animator.Play(PlayerAnimations.Base);
            _animator.Play(animationName);
        }
    }
}
