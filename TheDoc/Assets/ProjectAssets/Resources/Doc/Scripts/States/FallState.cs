using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class FallState : AirMovingState
    {
        public FallState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            base.Debug("Fall");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_character.IsGround || !_character.IsFalling) _stateMachine.ChangeState(_character.BaseState);
        }
    }
}