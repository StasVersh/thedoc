using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        [Inject] private Player _player;

        private Rigidbody2D _rigidbody;
        private Animator _animator;

        public void Move(float speedValue, float direction)
        {
            if (direction != 0.0f)
            {
                transform.localScale = direction > 0 ? new Vector3(1, 1) : new Vector3(-1, 1);
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
        public void Reset()
        {
            _rigidbody.velocity = Vector2.zero;
        }
        public void SetAnimation(string animationName)
        {
            _animator.Play(animationName);
        }

        private void OnEnable()
        {
            _player.Controller = this;
        }
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }
    }
}
