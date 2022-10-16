using System.Collections.Generic;
using Assets.ProjectAssets.Resources.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class SpawnPointController : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private Player _player;
        [SerializeField] public List<SpawnPointSetter> SpawnPointSetters;
        private void OnEnable()
        { 
            var player = _container.InstantiatePrefab(_player.Prefab);
            _player.GameObject = player;
            var index = _player.SpawnPointIndex;
            if (index > (SpawnPointSetters.Count - 1))
            {
                index = 0;
            }
            _player.GameObject.transform.position = SpawnPointSetters[index].transform.position;
        }
    }
}
