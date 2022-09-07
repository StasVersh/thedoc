using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class IdleState : UnmovableState
    {
        public IdleState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(PlayerAnimations.Idle);
            _player.Input.PlayerInput.Movement.performed += MovementOnPerformed;
            _player.Input.PlayerInput.Jump.started += JumpOnStarted;
        }

        public override void Exit()
        {
            base.Exit();
            _player.Input.PlayerInput.Movement.performed -= MovementOnPerformed;
            _player.Input.PlayerInput.Jump.started -= JumpOnStarted;
            _player.Controller.SetAnimation(PlayerAnimations.Base);
        }
        
        private void JumpOnStarted(InputAction.CallbackContext obj)
        {
            _stateMachine.ChangeState(_player.States.JumpingState);
        }   

        private void MovementOnPerformed(InputAction.CallbackContext obj)
        {
            _stateMachine.ChangeState(_player.States.RunningState);
        }
    }
}