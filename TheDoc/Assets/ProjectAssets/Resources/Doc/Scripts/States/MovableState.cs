using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public abstract class MovableState : PlayerState
    {
        protected float _direction;
        protected MovableState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            UpdateDirection();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            UpdateDirection();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _player.Controller.Move(_player.Speed, _direction);
        }

        private void UpdateDirection()
        {
            _direction = _player.Input.PlayerInput.Movement.ReadValue<float>();
        }
    }
}