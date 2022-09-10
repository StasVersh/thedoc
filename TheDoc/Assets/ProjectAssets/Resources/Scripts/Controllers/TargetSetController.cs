using Cinemachine;
using JetBrains.Annotations;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class TargetSetController : MonoBehaviour
    {
        [Inject] private Player _player;
        private void Start()
        {
            GetComponent<CinemachineVirtualCamera>().Follow = _player.GameObject.transform;
            GetComponent<CinemachineVirtualCamera>().LookAt = _player.GameObject.transform;
        }
    }
}