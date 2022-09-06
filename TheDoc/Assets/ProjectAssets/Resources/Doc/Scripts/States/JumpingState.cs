using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class JumpingState : MovableState
    {
        public JumpingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(PlayerAnimations.Jumping);
            _player.Input.PlayerInput.Jump.canceled += JumpOnCanceled;
            _player.Controller.Jump(_player.JumpSpeed);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_player.IsFalling)
            {
                _stateMachine.ChangeState(_player.States.FallingState);
            }
        }

        public override void Exit()
        {
            base.Enter();
            _player.Input.PlayerInput.Jump.canceled -= JumpOnCanceled;
            _player.Controller.SetAnimation(PlayerAnimations.Base);
        }
        
        private void JumpOnCanceled(InputAction.CallbackContext obj)
        {
            _player.Controller.StopJump();
            _stateMachine.ChangeState(_player.States.FallingState);
        }
    }
}