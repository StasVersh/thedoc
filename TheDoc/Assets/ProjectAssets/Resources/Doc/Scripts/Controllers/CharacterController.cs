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
        [SerializeField] private float _wallRayPosition;
        [SerializeField] private float _wallRayDistance;
        [SerializeField] private float _groundRayPosition;
        [SerializeField] private float _groundRayDistance;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _sprite;
        private StateMachine _characterStateMachine;
        private bool _colliderGround;

        #endregion

        #region Propertys

        public float Speed => _speed;
        public float JumpSpeed => _speed;
        public bool CanJump => CheckCanJump();
        public float HorizontalDirection { get; set; }
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
                _sprite.flipX = HorizontalDirection < 0;
            }
            _rigidbody.AddForce(new Vector2(HorizontalDirection, 0) * speedValue, ForceMode2D.Force);
        }

        public void Jump(float speedValue)
        {
            if(_rigidbody == null) return;
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
        
        private bool CheckCanJump()
        {
            var position = transform.position;
            int layerMasc = LayerMask.GetMask("Ground");
            
            var rightRay = Physics2D.Raycast(
                new Vector2(position.x, position.y + _wallRayPosition), 
                Vector2.right,
                _wallRayDistance,
                layerMasc);
            var leftRay = Physics2D.Raycast(
                new Vector2(position.x, position.y + _wallRayPosition), 
                Vector2.left,
                _wallRayDistance,
                layerMasc);
            var downRay = Physics2D.Raycast(
                new Vector2(position.x, position.y + _groundRayPosition), 
                Vector2.down,
                _groundRayDistance,
                layerMasc);
            
            var rightWall = rightRay.collider != null;
            var leftWall = leftRay.collider != null;
            var ground = downRay.collider != null;
            
            bool canJump;
            if (ground == true && _colliderGround == true) canJump = true;
            else if(!(rightWall || leftWall) && _colliderGround) canJump = true;
            else if (ground) canJump = true;
            else canJump = false;
            return canJump;
        }

        private void DebugUpdate()
        {
            var position = transform.position;
            Debug.DrawRay(new Vector2(position.x, position.y + _wallRayPosition), 
                Vector2.right * _wallRayDistance, Color.magenta);
            Debug.DrawRay(new Vector2(position.x, position.y + _wallRayPosition), 
                Vector2.left * _wallRayDistance, Color.magenta);
            Debug.DrawRay(new Vector2(position.x, position.y + _groundRayPosition), 
                Vector2.down * _groundRayDistance, Color.magenta);
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

            DebugUpdate();
            
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
                _colliderGround = true;
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
            _colliderGround = false;
        }

        #endregion
    }
}
