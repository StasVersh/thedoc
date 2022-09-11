using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class HookingState : MovableState
    {
        public HookingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.CanDash = true;
            _player.CanDoubleJump = true;
            _player.Input.PlayerInput.Jump.started += JumpOnStarted;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (CanHooking())
            {
                _player.Controller.VerticalAirBrake(_player.HookingForce, _player.HookingMaxSpeed);
            }
            else
            {
                _stateMachine.ChangeState(_player.States.FallingState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.Input.PlayerInput.Jump.started -= JumpOnStarted;
        }

        private void JumpOnStarted(InputAction.CallbackContext obj)
        {
            _stateMachine.ChangeState(_player.States.HookingJumpState);
        }
    }
}