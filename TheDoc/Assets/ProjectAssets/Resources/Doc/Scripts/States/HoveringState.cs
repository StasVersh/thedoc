using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class HoveringState : MovableState
    {
        public HoveringState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(PlayerAnimations.Hovering);
            _player.Input.PlayerInput.Jump.canceled += JumpOnCanceled;
            _player.HoverParticles.Play();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _player.Controller.Hover(_player.HoverForce, _player.HoverMaxSpeed);
            if (_player.CanJump)
            {
                _stateMachine.ChangeState(_player.States.GroundedBaseState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.Controller.SetAnimation(PlayerAnimations.Base);
            _player.Input.PlayerInput.Jump.canceled -= JumpOnCanceled;
            _player.HoverParticles.Stop();
        }

        private void JumpOnCanceled(InputAction.CallbackContext obj)
        {
            _stateMachine.ChangeState(_player.States.FallingState);
        }
    }
}