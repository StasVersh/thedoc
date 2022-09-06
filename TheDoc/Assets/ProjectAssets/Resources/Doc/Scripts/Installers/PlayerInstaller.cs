using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _prefab;
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(new Player(_prefab)).AsSingle();
        }
    }
}