using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class DashingState : UnmovableState
    {
        private float freezeDirection;
        
        public DashingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.CanDash = false;
            _player.Controller.SetAnimation(PlayerAnimations.Dashing);
            _player.Controller.DashingStart(_player.DashSpeed, _player.DashHeight);
            _player.DashWayParticles.Play();
            _player.DashParticles.Play();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _player.Controller.DashingBrake(_player.DashDistance);
            if (_player.Controller.DashEnding())
            {
                _stateMachine.ChangeState(_player.States.FallingState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.Controller.SetAnimation(PlayerAnimations.Base);
            _player.DashWayParticles.Stop();
            _player.DashParticles.Stop();
        }
    }
}