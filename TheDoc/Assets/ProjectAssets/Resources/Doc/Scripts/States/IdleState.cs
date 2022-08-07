﻿using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class IdleState : UnmovableState
    {
        public IdleState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(CharacterAnimations.Idle);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                _stateMachine.ChangeState(_player.States.RunningState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _player.Controller.SetAnimation(CharacterAnimations.Base);
        }
    }
}