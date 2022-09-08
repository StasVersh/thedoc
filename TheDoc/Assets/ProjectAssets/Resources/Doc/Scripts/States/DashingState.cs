using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
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
            _player.Controller.DashingStart(_player.DashStartSpeed);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _player.Controller.DashingBrake(_player.DashBreakForce);
            if (_player.Controller.DashEnding())
            {
                _stateMachine.ChangeState(_player.States.FallingState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.CanDash = false;
        }
    }
}