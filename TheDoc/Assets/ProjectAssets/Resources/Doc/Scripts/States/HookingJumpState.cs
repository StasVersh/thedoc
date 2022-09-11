using System.Threading.Tasks;
using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine.InputSystem;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class HookingJumpState : UnmovableState
    {
        private bool _canMove;
        public HookingJumpState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            
            var task = Task.Run(async delegate
            {
                await Task.Delay((int)_player.HookingSpeed);
                return true;
            });
            task.Wait();
            _canMove = task.Result;
            _player.Controller.SetAnimation(PlayerAnimations.Jumping);
            _player.Input.PlayerInput.Jump.canceled += JumpOnCanceled;
            _player.Controller.Jump(_player.HookingJumpSpeed, -_direction);
            _player.FallParticles.Play();
            _player.JumpParticles.Play();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_player.IsFalling)
            {
                _stateMachine.ChangeState(_player.States.FallingState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (_canMove)
            {
                _player.Controller.Move(_player.Speed, _direction);
            }
        }

        public override void Exit()
        {
            base.Enter();
            _canMove = false;
            _player.Input.PlayerInput.Jump.canceled -= JumpOnCanceled;
            _player.Controller.SetAnimation(PlayerAnimations.Base);
            _player.FallParticles.Stop();
            _player.JumpParticles.Stop();
        }
        
        private void JumpOnCanceled(InputAction.CallbackContext obj)
        {
            _canMove = true;
        }
    }
}