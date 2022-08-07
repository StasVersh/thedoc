using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class RunningState : MovableState
    {
        public RunningState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(CharacterAnimations.Running);
            _player.DustRunParticles.Play();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_direction == 0)
            {
                _stateMachine.ChangeState(_player.States.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.Controller.SetAnimation(CharacterAnimations.Base);
            _player.DustRunParticles.Stop();
        }
    }
}