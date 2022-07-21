using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using Unity.VisualScripting;
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
            _character.Reset();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _stateMachine.ChangeState(_character.IdleState);
            if(_character.IsFalling) _stateMachine.ChangeState(_character.FallState);
            
        }
    }
}