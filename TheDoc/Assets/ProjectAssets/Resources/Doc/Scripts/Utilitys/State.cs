using Unity.VisualScripting;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public abstract class State
    {
        protected StateMachine _stateMachine;
        protected CharacterController _character;

        public State(StateMachine stateMachine, CharacterController character)
        {
            _stateMachine = stateMachine;
            _character = character;
        }
        
        public virtual void Enter()
        {
            
        }

        public virtual void HandleInput()
        {

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void Exit()
        {

        }
        
    }
}