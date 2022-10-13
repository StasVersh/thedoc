using System.Collections;
using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.InputSystem;
using Input = UnityEngine.Windows.Input;
    
namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class IdleState : MovableState
    {
        private IEnumerator _hold;
        public IdleState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _hold = Hold();
            _player.Controller.SetAnimation(PlayerAnimations.Idle);
            _player.Input.PlayerInput.Movement.performed += MovementOnPerformed;
            _player.Input.PlayerInput.Jump.started += JumpOnStarted;
            _player.Input.PlayerInput.CameraHold.started += context => _player.Controller.StartCoroutine(_hold);
            _player.Input.PlayerInput.CameraHold.canceled += context => _player.Controller.StopAllCoroutines();
            _player.Controller.Reset();
            _player.SteamController.StartSteam();
        }

        private IEnumerator Hold()
        {
           yield return new WaitForSeconds(1);
           _stateMachine.ChangeState(_player.States.LookingState);
        }

        public override void Exit()
        {
            base.Exit();
            _player.Input.PlayerInput.Movement.performed -= MovementOnPerformed;
            _player.Input.PlayerInput.Jump.started -= JumpOnStarted;
            _player.Controller.SetAnimation(PlayerAnimations.Base);
            _player.SteamController.StopSteam();
        }
        
        private void JumpOnStarted(InputAction.CallbackContext obj)
        {
            _stateMachine.ChangeState(_player.States.JumpingState);
        }

        private void MovementOnPerformed(InputAction.CallbackContext obj)
        {
            _stateMachine.ChangeState(_player.States.RunningState);
        }
    }
}