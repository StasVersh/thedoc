using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using ProjectAssets.Resources.Scripts.Utilitys;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class PlayerState : State
    {
        protected Player _player;
        protected float _direction;
        public PlayerState(StateMachine stateMachine, Player player) : base(stateMachine)
        {
            _player = player;
            EventHandler.ThromsDeth.AddListener(ThromsDeth);
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
        
        private void UpdateDirection()
        {
            _direction = _player.Input.PlayerInput.Movement.ReadValue<float>();
        }

        private void ThromsDeth()
        {
            _stateMachine.ChangeState(_player.States.ThomsDethState);
        }
    }
}