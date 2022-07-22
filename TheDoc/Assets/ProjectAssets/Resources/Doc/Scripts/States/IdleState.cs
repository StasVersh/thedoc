using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class IdleState : GroundedState
    {
        public IdleState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
        }

        public override void Enter()
        {
            base.Enter();
            base.Debug("Idle");
            if(Input.GetAxisRaw("Horizontal") == 0.0f) _character.Reset();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_character.HorizontalDirection != 0.0f)
            {
                _stateMachine.ChangeState(_character.RunState);
            }
        }
    }
}