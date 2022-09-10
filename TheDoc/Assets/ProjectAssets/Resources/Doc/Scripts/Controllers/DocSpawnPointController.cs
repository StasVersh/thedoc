using System;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class DocSpawnPointController : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private Player _player;
        private void OnEnable()
        { 
            var player = _container.InstantiatePrefab(_player.GameObject);
            _player.GameObject = player;
            _player.GameObject.transform.position = transform.position;
        }
    }
}
