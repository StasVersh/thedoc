using System;
using ProjectAssets.Resources.Doc.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class DocSpawnPointController : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;

        private void OnEnable()
        {
            Instantiate(_playerPrefab, transform.position, Quaternion.identity, null);
        }
    }
}
