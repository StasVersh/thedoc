using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Scripts.Utilitys;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class PlayerState : State
    {
        protected Player _player;
        public PlayerState(StateMachine stateMachine, Player player) : base(stateMachine)
        {
            _player = player;
        }
    }
}