using UnityEngine.Events;

namespace ProjectAssets.Resources.Doc.Scripts.Utilitys
{
    public static class InputHandler
    {
        public static UnityEvent InteractiveWithObjects = new UnityEvent();
        public static UnityEvent Jump = new UnityEvent();
        public static UnityEvent StopJump = new UnityEvent();
        public static UnityEvent<float> Moving = new UnityEvent<float>();
    }
}