using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
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
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                _stateMachine.ChangeState(_player.States.IdleState);
            }
            else
            {
                _stateMachine.ChangeState(_player.States.RunningState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.DustFallParticles.Play();
            _player.Controller.SetAnimation(PlayerAnimations.Base);
        }
    }
}