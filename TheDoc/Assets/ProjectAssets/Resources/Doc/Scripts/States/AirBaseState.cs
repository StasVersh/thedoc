using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class AirBaseState : MovableState
    {
        public AirBaseState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            if (_player.IsFalling)
            {
                _stateMachine.ChangeState(_player.States.FallingState);
            }
        }
    }
}