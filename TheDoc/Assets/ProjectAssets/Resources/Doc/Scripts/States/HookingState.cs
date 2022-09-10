using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class HookingState : MovableState
    {
        public HookingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.CanDash = true;
            _player.CanDoubleJump = true;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (CanHooking())
            {
                _player.Controller.AirBrake(_player.HookingForce, _player.HookingMaxSpeed);
            }
            else
            {
                _stateMachine.ChangeState(_player.States.FallingState);
            }
        }
    }
}