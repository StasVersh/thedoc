using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Scripts.Utilitys;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class UnmovableState : PlayerState
    {
        public UnmovableState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            _player.Controller.Reset();
        }
    }
}