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
        }

        public override void Enter()
        {
            base.Enter();
            InputHandler.Jump.AddListener(Jump);
        }

        public override void HandleInput()
        {
            base.HandleInput();
            _character.HorizontalDirection = Input.GetAxisRaw("Horizontal");
        }

        public override void Exit()
        {
            base.Exit();
            InputHandler.Jump.RemoveListener(Jump);
        }

        private void Jump()     
        {
            if(_character.CanJump) _stateMachine.ChangeState(_character.JumpState);
        }
    }
}