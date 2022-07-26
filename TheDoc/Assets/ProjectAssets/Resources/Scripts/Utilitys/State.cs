﻿using CharacterController = ProjectAssets.Resources.Doc.Scripts.Controllers.CharacterController;
using StateMachine = ProjectAssets.Resources.Doc.Scripts.Controllers.StateMachine;

namespace ProjectAssets.Resources.Doc.Scripts.Utilitys
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
        
        public void Debug(string log)
        {
            EventHandler.StateChanging.Invoke(log);
            //UnityEngine.Debug.Log(log);
        }
        
    }
}