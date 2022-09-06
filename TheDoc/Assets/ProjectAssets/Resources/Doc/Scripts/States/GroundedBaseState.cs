using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class GroundedBaseState : MovableState
    {
        public GroundedBaseState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            if (_direction != 0)
            {
                _stateMachine.ChangeState(_player.States.RunningState);
            }
            else
            {
                _stateMachine.ChangeState(_player.States.IdleState);
            }
        }
    }
}