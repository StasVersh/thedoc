using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.States;
using ProjectAssets.Resources.Scripts.Utilitys;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class StateManager : MonoBehaviour
    {
        [Inject] private Player _player;
        
        public StateMachine _stateMachine;

        public FallingState FallingState { get; private set; }
        public IdleState IdleState { get; private set; }
        public RunningState RunningState { get; private set; }
        public JumpingState JumpingState { get; private set; }
        public GroundedBaseState GroundedBaseState { get; private set; }
        public HoveringState HoveringState { get; private set; }
        public DashingState DashingState { get; private set; }
        public DoubleJumpState DoubleJumpState { get; private set; }
        private void OnEnable()
        {
            _player.States = this;
        }
        
        private void Start()
        {
            _stateMachine = new StateMachine();

            FallingState = new FallingState(_stateMachine, _player);
            IdleState = new IdleState(_stateMachine, _player);
            RunningState = new RunningState(_stateMachine, _player);
            JumpingState = new JumpingState(_stateMachine, _player);
            GroundedBaseState = new GroundedBaseState(_stateMachine, _player);
            HoveringState = new HoveringState(_stateMachine, _player);
            DashingState = new DashingState(_stateMachine, _player);
            DoubleJumpState = new DoubleJumpState(_stateMachine, _player);

            _stateMachine.Initialize(FallingState);
        }
        
        private void Update()
        {   
            _stateMachine.CurrentState.HandleInput();
            _stateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.PhysicsUpdate();
        }
    }
}