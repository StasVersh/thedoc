﻿using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Values;
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
            _character.SetAnimation(CharacterAnimations.Running);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_character.HorizontalDirection == 0.0f)
            {
                _stateMachine.ChangeState(_character.IdleState);
            }
            if (!_character.IsGround)
            {
                _stateMachine.ChangeState(_character.FallState);
            }

            if (_character.IsWall)
            {
                _stateMachine.ChangeState(_character.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _character.Move(_character.Speed);
        }

        public override void Exit()
        {
            base.Exit();
            _character.SetAnimation(CharacterAnimations.Base);
        }
    }
}