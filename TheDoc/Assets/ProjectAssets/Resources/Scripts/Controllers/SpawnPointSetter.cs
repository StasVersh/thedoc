using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace Assets.ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpawnPointSetter : MonoBehaviour
    {
        [Inject] private Player _player;
        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                _player.SpawnPoint = this;
            }
        }
    }
}
