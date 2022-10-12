using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.States;
using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using ProjectAssets.Resources.Doc.Scripts.Values;
using System.Collections;
using UnityEngine;

namespace Assets.ProjectAssets.Resources.Doc.Scripts.States
{
    public class ThomsDethState : UnmovableState
    {
        public ThomsDethState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(PlayerAnimations.Base);
            _player.Controller.StartCoroutine(CompliteState());
        }

        public override void Exit()
        {
            base.Exit();
            _player.Controller.SetAnimation(PlayerAnimations.Base);
        }

        private IEnumerator CompliteState()
        {
            yield return new WaitForSeconds(0.5f);
            EventHandler.Spawn.Invoke();
            _stateMachine.ChangeState(_player.States.ThomsSpawningState);
        }
    }
}
