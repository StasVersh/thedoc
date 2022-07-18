using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;
using UnityEngine.Rendering;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class IdleState : GroundedState
    {
        public IdleState(StateMachine stateMachine, CharacterController character) 
            : base(stateMachine, character)
        {
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if (Input.GetAxis("Horizontal") != 0.0f && _character.IsGround) _stateMachine.ChangeState(_character.RunningState);
        }
    }
}