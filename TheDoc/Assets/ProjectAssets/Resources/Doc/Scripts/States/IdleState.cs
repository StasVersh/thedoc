﻿using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class IdleState : GroundedState
    {
        public IdleState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
        }

        public override void Enter()
        {
            base.Enter();
            base.Debug("Idle");
            if(Input.GetAxisRaw("Horizontal") == 0.0f) _character.Reset();
            _character.SetAnimation(CharacterAnimations.Idle);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_character.HorizontalDirection != 0.0f)
            {
                _stateMachine.ChangeState(_character.RunState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _character.SetAnimation(CharacterAnimations.Base);
        }
    }
}