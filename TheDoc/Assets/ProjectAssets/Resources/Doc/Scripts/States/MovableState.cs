using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Scripts.Utilitys;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public abstract class MovableState : PlayerState
    {
        protected MovableState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _player.Controller.Move(_player.Speed, Input.GetAxisRaw("Horizontal"));
        }
    }
}