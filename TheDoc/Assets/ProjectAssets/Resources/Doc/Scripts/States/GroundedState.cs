using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public abstract class GroundedState : State
    {
        protected GroundedState(StateMachine stateMachine, CharacterController character) 
            : base(stateMachine, character)
        {
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if(_character.IsGround && Input.GetKeyDown(KeyCode.Space)) _stateMachine.ChangeState(_character.JumpingState);
        }
    }
}