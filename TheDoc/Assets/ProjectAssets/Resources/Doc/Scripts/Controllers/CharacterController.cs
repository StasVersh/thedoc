using System;
using System.Collections;
using ProjectAssets.Resources.Doc.Scripts.States;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
    public class CharacterController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _coyoteTime;
        [SerializeField] private float _wallRayDistance;
        [SerializeField] private Vector2 _wallRayStart;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _sprite;
        private StateMachine _characterStateMachine;

        #endregion

        #region Propertys

        public float Speed => _speed;
        public float JumpSpeed => _speed;
        public float HorizontalDirection { get; set; }

        public bool IsGround { get; private set; }
        public bool IsWall;// { get; private set; }
        public bool IsFalling { get; private set; }
        public BaseState BaseState { get; private set; }
        public JumpState JumpState { get; private set; }
        public FallState FallState { get; private set; }
        public IdleState IdleState { get; private set; }
        public RunState RunState { get; private set; }

        #endregion

        #region Methods

        public void Move(float speedValue)
        {
            _rigidbody.velocity = new Vector2 (speedValue * HorizontalDirection, _rigidbody.velocity.y);
            if (HorizontalDirection != 0.0f)
            {
                if (HorizontalDirection < 0)
                {
                    _sprite.flipX = true;
                }
                else
                {
                    _sprite.flipX = false;
                }
            }
            _rigidbody.AddForce(new Vector2(HorizontalDirection, 0) * speedValue, ForceMode2D.Force);
        }

        public void Jump(float speedValue)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
        }
        
        public void StopJump()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }
        
        public void Reset()
        {
            _rigidbody.velocity = Vector2.zero;
        }
        
        public void SetAnimation(string name)
        {
            _animator.Play(name);
        }

        #endregion

        #region Unity Events Methods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            
            _characterStateMachine = new StateMachine();

            BaseState = new BaseState(_characterStateMachine, this);
            JumpState = new JumpState(_characterStateMachine, this);
            FallState = new FallState(_characterStateMachine, this);
            IdleState = new IdleState(_characterStateMachine, this);
            RunState = new RunState(_characterStateMachine, this);
            
            _characterStateMachine.Initialize(BaseState);
        }

        private void Update()
        {   
            _characterStateMachine.CurrentState.HandleInput();

            int layer = LayerMask.GetMask("Ground");
            var position = new Vector3(transform.position.x + _wallRayStart.x, transform.position.y + _wallRayStart.y);
            Debug.DrawRay(position, Vector3.left * _wallRayDistance, Color.red);
            Debug.DrawRay(position, Vector3.right * _wallRayDistance, Color.red);

            var rightRay = Physics2D.Raycast(position, Vector2.right, _wallRayDistance, layer);
            var leftRay = Physics2D.Raycast(position, Vector2.left, _wallRayDistance, layer);
            
            IsWall = rightRay.collider != null || leftRay.collider != null;

            _characterStateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            IsFalling = _rigidbody.velocity.y < 0;

            _characterStateMachine.CurrentState.PhysicsUpdate();
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag(Tags.Ground))
            {
                IsGround = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Ground))
            {
                StartCoroutine(StartCoyoteTime());
            }
        }
        private IEnumerator StartCoyoteTime()
        {
            yield return new WaitForSeconds(_coyoteTime);
            IsGround = false;
        }

        #endregion
    }
}
