using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;
using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class JumpingState : State
    {
        public JumpingState(StateMachine stateMachine, CharacterController character) 
            : base(stateMachine, character)
        {
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if(_character.IsGround) _character.Jump(_character.JumpSpeed);
            else
            {
                _stateMachine.ChangeState(_character.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _character.Run(_character.Speed, Input.GetAxisRaw("Horizontal"));
        }
    }
}