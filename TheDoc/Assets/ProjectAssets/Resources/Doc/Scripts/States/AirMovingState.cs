using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class AirMovingState : State
    {
        public AirMovingState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
        }
        
        public override void HandleInput()
        {
            base.HandleInput();
            _character.HorizontalDirection = Input.GetAxisRaw("Horizontal");
        }
        
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _character.Move(_character.Speed);
        }
    }
}