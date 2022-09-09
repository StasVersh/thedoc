using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine.InputSystem;
using StateMachine = ProjectAssets.Resources.Doc.Scripts.Controllers.StateMachine;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class FallingState : MovableState
    {
        public FallingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(PlayerAnimations.Falling);
            _player.Input.PlayerInput.Jump.started += JumpOnStarted;
            _player.Input.PlayerInput.Hover.started += HoverOnStarted;
            if (_player.Input.PlayerInput.Jump.IsPressed() && _player.HaveHover)
            {
                _stateMachine.ChangeState(_player.States.HoveringState);
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!_player.CanJump) return;
            _stateMachine.ChangeState(_player.States.GroundedBaseState);
            _player.FallParticles.Play();
            if (!_player.IsFalling)
            {
                _player.Controller.ResetY();
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.Input.PlayerInput.Jump.started -= JumpOnStarted;
            _player.Input.PlayerInput.Hover.started -= HoverOnStarted;
            _player.Controller.SetAnimation(PlayerAnimations.Base);
        }

        private void JumpOnStarted(InputAction.CallbackContext obj)
        {
            if (_player.CanDoubleJump && _player.HaveDoubleJump)
            {
                _stateMachine.ChangeState(_player.States.DoubleJumpState);
            }
            else if(_player.HaveHover)
            {
                _stateMachine.ChangeState(_player.States.HoveringState);
            }
        }

        private void HoverOnStarted(InputAction.CallbackContext obj)
        {
            if (_player.HaveHover)
            {
                _stateMachine.ChangeState(_player.States.HoveringState);
            }
        }
    }
}