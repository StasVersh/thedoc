using System;
using ProjectAssets.Resources.Doc.Scripts.States;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;

        private Rigidbody2D _rigidbody;
        private StateMachine _characterStateMachine;

        #endregion

        #region Propertys

        public float Speed => _speed;
        public float JumpSpeed => _speed;
        public float HorizontalDirection { get; set; }

        public bool IsGround { get; private set; }
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
            _rigidbody.AddForce(new Vector2(HorizontalDirection, 0) * speedValue, ForceMode2D.Force);
        }

        public void Jump(float speedValue)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
        }

        #endregion

        #region Unity Events Methods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
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
            _characterStateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.velocity.y < 0) IsFalling = true;
            else
            {
                IsFalling = false;
            }
            
            _characterStateMachine.CurrentState.PhysicsUpdate();
        }

        private void OnTriggerEnter2D(Collider2D col)
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
                IsGround = false;
            }
        }

        #endregion

        public void Reset()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
