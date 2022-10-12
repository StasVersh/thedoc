using UnityEngine.Events;

namespace ProjectAssets.Resources.Doc.Scripts.Utilitys
{
    public static class EventHandler
    {
        public static UnityEvent LocationExit = new UnityEvent();
        public static UnityEvent ThromsDeth = new UnityEvent();
        public static UnityEvent Spawn = new UnityEvent();
    }
}