using ProjectAssets.Resources.Doc.Scripts.Controllers;
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

        public override void Enter()
        {
            base.Enter();
            base.Debug("Jump");
            _character.Jump(_character.JumpSpeed);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_character.IsFalling) _stateMachine.ChangeState(_character.FallState); 
        }
    }
}