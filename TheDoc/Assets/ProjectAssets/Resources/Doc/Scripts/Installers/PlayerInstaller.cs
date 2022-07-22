using ProjectAssets.Resources.Doc.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        public override void InstallBindings()
        {
            var player = Container.InstantiatePrefab(_playerPrefab);
            var playerModel = new PlayerModel(player);
            Container.Bind<PlayerModel>().FromInstance(playerModel).AsSingle();
        }
    }
}