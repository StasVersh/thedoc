using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using Unity.VisualScripting;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;
using State = ProjectAssets.Resources.Doc.Scripts.Utilitys.State;
using StateMachine = ProjectAssets.Resources.Doc.Scripts.Controllers.StateMachine;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class BaseState : Utilitys.State
    {
        public BaseState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
        }

        public override void Enter()
        {
            base.Enter();
            base.Debug("Base");
            if(Input.GetAxisRaw("Horizontal") == 0.0f) _character.Reset();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_character.CanJump) _stateMachine.ChangeState(_character.IdleState);
            else if(_character.IsFalling)
            { 
                _stateMachine.ChangeState(_character.FallState);
            }
        }
    }
}