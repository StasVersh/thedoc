using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class DoubleJumpState : MovableState
    {
        public DoubleJumpState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            _player.CanDoubleJump = false;
            _player.Controller.SetAnimation(PlayerAnimations.DoubleJumping);
            _player.Input.PlayerInput.Jump.canceled += JumpOnCanceled;
            _player.Controller.Jump(_player.DoubleJumpSpeed, 0);
            _player.FallParticles.Play();
            _player.JumpParticles.Play();
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
            base.Exit();
            _player.Controller.SetAnimation(PlayerAnimations.Base);
            _player.Input.PlayerInput.Jump.canceled -= JumpOnCanceled;
            _player.FallParticles.Stop();
            _player.JumpParticles.Stop();
        }
        
        private void JumpOnCanceled(InputAction.CallbackContext obj)
        {
            _player.Controller.StopJump();
            _stateMachine.ChangeState(_player.States.FallingState);
        }
    }
}