using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;

namespace ProjectAssets.Resources.Doc.Scripts.States
{
    public class HookingState : MovableState
    {
        public HookingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }
    }
}