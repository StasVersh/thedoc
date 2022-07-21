using ProjectAssets.Resources.Doc.Scripts.Controllers;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class RunState : GroundedState
    {
        public RunState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            base.Debug("Run");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_character.HorizontalDirection == 0.0f || !_character.IsGround)
            {
                _stateMachine.ChangeState(_character.BaseState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _character.Move(_character.Speed);
        }
    }
}