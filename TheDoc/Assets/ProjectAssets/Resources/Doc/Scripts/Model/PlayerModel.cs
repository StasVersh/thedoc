using UnityEngine;

namespace ProjectAssets.Resources.Doc.Model
{
    public class PlayerModel
    {
        public GameObject GameObject { get; private set; }
        
        public PlayerModel(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}