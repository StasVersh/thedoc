using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using StateMachine = ProjectAssets.Resources.Doc.Scripts.Controllers.StateMachine;

namespace ProjectAssets.Resources.Scripts.Utilitys
{
    public abstract class State
    {
        protected StateMachine _stateMachine;

        public State(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
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
        }
        
    }
}