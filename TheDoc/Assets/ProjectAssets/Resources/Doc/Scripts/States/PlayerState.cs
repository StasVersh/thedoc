using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Scripts.Utilitys;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class PlayerState : State
    {
        protected Player _player;
        protected float _direction;
        public PlayerState(StateMachine stateMachine, Player player) : base(stateMachine)
        {
            _player = player;
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
        
        protected bool CanHooking()
        {
            return _player.IsWallHit && !_player.CanJump && _direction == _player.FaceDirection;
        }
    }
}