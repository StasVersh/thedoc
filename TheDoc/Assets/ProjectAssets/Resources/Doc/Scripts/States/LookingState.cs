using DG.Tweening;
using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class LookingState : MovableState
    {
        private float _value;
        public LookingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Controller.SetAnimation(PlayerAnimations.Falling);
            _value = _player.Input.PlayerInput.CameraHold.ReadValue<float>();
            if (_value > 0)
            {
                _player.CameraTarget.transform.DOMove
                    (_player.UpCameraPosition.transform.position, _player.CameraMoveSpeed);
            }
            else if (_value < 0)
            {
                _player.CameraTarget.transform.DOMove
                    (_player.DownCameraPosition.transform.position , _player.CameraMoveSpeed);
            }
            else if (_value == 0)
            {
                _player.CameraTarget.transform.DOMove
                    (_player.Controller.transform.position, _player.CameraMoveSpeed);
            }
            _player.Input.PlayerInput.CameraHold.canceled += ReturnCamera;
        }

        private void ReturnCamera(InputAction.CallbackContext obj)
        {
            _stateMachine.ChangeState(_player.States.GroundedBaseState);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _value = _player.Input.PlayerInput.CameraHold.ReadValue<float>();
            if (_direction != 0)
            {
                _stateMachine.ChangeState(_player.States.GroundedBaseState);
            }
        }
        
        public override void Exit()
        {
            base.Exit();
            _player.CameraTarget.transform.DOMove(_player.Controller.transform.position, _player.CameraMoveSpeed);
            _player.Input.PlayerInput.CameraHold.canceled -= ReturnCamera;

        }
    }
}