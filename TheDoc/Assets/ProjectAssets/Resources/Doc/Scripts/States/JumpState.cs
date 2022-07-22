using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using UnityEngine;
using UnityEngine.EventSystems;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class JumpState : AirMovingState
    {
        public JumpState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
        }

        private void StopJump()
        {
             _character.StopJump();
        }

        public override void Enter()
        {
            base.Enter();
            InputHandler.StopJump.AddListener(StopJump);
            base.Debug("Jump");
            _character.Jump(_character.JumpSpeed);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_character.IsFalling) _stateMachine.ChangeState(_character.FallState); 
        }

        public override void Exit()
        {
            base.Exit();
            InputHandler.StopJump.RemoveListener(StopJump);
        }
    }
}