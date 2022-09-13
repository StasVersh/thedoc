using System.Collections.Generic;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class DocSpawnPointController : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private Player _player;
        [SerializeField] private List<GameObject> _spawnPoints;
        private void OnEnable()
        { 
            var player = _container.InstantiatePrefab(_player.Prefab);
            _player.GameObject = player;
            var index = _player.SpawnPointIndex;
            if (index > (_spawnPoints.Count - 1))
            {
                index = 0;
            }
            _player.GameObject.transform.position = _spawnPoints[index].transform.position;
        }
    }
}
