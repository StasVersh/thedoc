using UnityEngine.Events;

namespace ProjectAssets.Resources.Doc.Scripts.Utilitys
{
    public static class EventHandler
    {
        public static UnityEvent<string> StateChanging = new UnityEvent<string>();
    }
}