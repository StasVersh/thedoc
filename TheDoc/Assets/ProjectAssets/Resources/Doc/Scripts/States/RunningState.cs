using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Installers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class RunningState : MovableState
    {
        public RunningState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(PlayerAnimations.Running);
            _player.Input.PlayerInput.Jump.started += JumpOnStarted;
            _player.RunParticles.Play();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_player.IsFalling && !_player.CanJump)
            {
                _stateMachine.ChangeState(_player.States.FallingState);
            }
            if (_direction == 0)
            {
                _stateMachine.ChangeState(_player.States.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.Controller.SetAnimation(PlayerAnimations.Base);
            _player.Input.PlayerInput.Jump.started -= JumpOnStarted;
            _player.RunParticles.Stop();
        }
        
        private void JumpOnStarted(InputAction.CallbackContext obj)
        {
            _stateMachine.ChangeState(_player.States.JumpingState);
        } 
    }
}