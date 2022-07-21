using UnityEngine.Events;

namespace ProjectAssets.Resources.Doc.Scripts.Utilitys
{
    public static class InputHandler
    {
        public static UnityEvent Jump = new UnityEvent();
        public static UnityEvent<float> Moving = new UnityEvent<float>();
    }
}