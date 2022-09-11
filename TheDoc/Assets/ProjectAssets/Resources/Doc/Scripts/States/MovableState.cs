using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public abstract class MovableState : PlayerState
    {
        protected MovableState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();            
            _player.Input.PlayerInput.Dash.started += DashOnStarted;
        }

        private void DashOnStarted(InputAction.CallbackContext obj)
        {
            if (_player.HaveDash && _player.CanDash)
            {
                _stateMachine.ChangeState(_player.States.DashingState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.Input.PlayerInput.Dash.started -= DashOnStarted;
        }
        
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _player.Controller.Move(_player.Speed, _direction);
        }
    }
}