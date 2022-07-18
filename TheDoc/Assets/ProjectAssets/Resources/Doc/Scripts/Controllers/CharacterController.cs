using System;
using ProjectAssets.Resources.Doc.Scripts.States;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float speed;
        [SerializeField] private float jumpSpeed;
        
        public IdleState IdleState;
        public RunningState RunningState;
        public JumpingState JumpingState;

        public bool _isGround;
        private Rigidbody2D _rigidbody;
        private StateMachine _characterStateMachine;

        #endregion

        #region Propertys

        public float Speed => speed;
        public float JumpSpeed => speed;
        public bool IsGround => _isGround;

        #endregion

        #region Methods

        public void Run(float speedValue, float horizontalDirection)
        {
            _rigidbody.velocity = new Vector2 (speedValue * horizontalDirection, _rigidbody.velocity.y);
            _rigidbody.AddForce(new Vector2(horizontalDirection, 0) * speedValue, ForceMode2D.Force);
        }

        public void Jump(float speedValue)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(Vector2.up * speedValue, ForceMode2D.Impulse);
        }

        #endregion

        #region Unity Events Methods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _characterStateMachine = new StateMachine();
            
            IdleState = new IdleState(_characterStateMachine, this);
            RunningState = new RunningState(_characterStateMachine, this);
            JumpingState = new JumpingState(_characterStateMachine, this);
            
            _characterStateMachine.Initialize(IdleState);
        }

        private void Update()
        {   
            _characterStateMachine.CurrentState.HandleInput();
            _characterStateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            _characterStateMachine.CurrentState.PhysicsUpdate();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.Ground))
            {
                _isGround = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Ground))
            {
                _isGround = false;
            }
        }

        #endregion
    }
}
