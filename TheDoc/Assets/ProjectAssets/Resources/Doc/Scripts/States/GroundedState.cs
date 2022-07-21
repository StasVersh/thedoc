using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class GroundedState : State
    {
        public GroundedState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
            InputHandler.Jump.AddListener(Jump);
        }
        
        public override void HandleInput()
        {
            base.HandleInput();
            _character.HorizontalDirection = Input.GetAxisRaw("Horizontal");
        }

        private void Jump()
        {
            if(_character.IsGround) _stateMachine.ChangeState(_character.JumpState);
        }
    }
}