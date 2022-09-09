using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using StateMachine = ProjectAssets.Resources.Doc.Scripts.Controllers.StateMachine;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class FallingState : MovableState
    {
        public FallingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(PlayerAnimations.Falling);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!_player.CanJump) return;
            _stateMachine.ChangeState(_player.States.GroundedBaseState);
        }

        public override void Exit()
        {
            base.Exit();
            _player.FallParticles.Play();
            _player.Controller.SetAnimation(PlayerAnimations.Base);
        }
    }
}