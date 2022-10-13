using UnityEngine;
using ProjectAssets.Resources.Doc.Scripts.Model;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class CameraTargetController : MonoBehaviour
    {
        [SerializeField] private GameObject _upCameraPosition;
        [SerializeField] private GameObject _downCameraPosition;
        [SerializeField] private GameObject _cameraTarget;
        [SerializeField] private float _cameraMoveSpeed;
        
        [Inject] private Player _player;

        private void Awake()
        {
            _player.CameraTarget = _cameraTarget;
            _player.UpCameraPosition = _upCameraPosition;
            _player.DownCameraPosition = _downCameraPosition;
            _player.CameraMoveSpeed = _cameraMoveSpeed;
        }
    }
}
