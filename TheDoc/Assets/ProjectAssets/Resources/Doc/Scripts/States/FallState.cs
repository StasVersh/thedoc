﻿using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class FallState : AirMovingState
    {
        public FallState(StateMachine stateMachine, CharacterController character) : base(stateMachine, character)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            _character.SetAnimation(CharacterAnimations.Falling);
            base.Debug("Fall");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_character.IsGround || !_character.IsFalling) _stateMachine.ChangeState(_character.BaseState);
        }
        
        public override void Exit()
        {
            base.Exit();
            _character.SetAnimation(CharacterAnimations.Falling);

        }
    }
    
}