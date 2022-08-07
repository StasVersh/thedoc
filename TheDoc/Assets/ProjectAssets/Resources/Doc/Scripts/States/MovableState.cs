using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Scripts.Utilitys;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public abstract class MovableState : PlayerState
    {
        protected float _direction;
        protected MovableState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void HandleInput()
        {
            base.HandleInput();
            _direction = _player.Input.PlayerInput.Movement.ReadValue<float>();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _player.Controller.Move(_player.Speed, _direction);
        }
    }
}