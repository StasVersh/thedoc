using System;
using UnityEngine;
using DG.Tweening;
using ProjectAssets.Resources.Doc.Scripts.Controllers;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine.InputSystem;
using Zenject;
using Key = UnityEngine.InputSystem.Key;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class CameraTargetController : MonoBehaviour
    {
        [SerializeField] private GameObject _upCameraPosition;
        [SerializeField] private GameObject _idleCameraPosition;
        [SerializeField] private GameObject _downCameraPosition;
        
        [Inject] private Player _player;

        private void Awake()
        {
            _player.Input.PlayerInput.CameraHoldUp.started += CameraHoldUp;
            _player.Input.PlayerInput.CameraHoldDown.started += CameraHoldDown;
        }

        private void CameraHoldUp(InputAction.CallbackContext obj)
        {
            gameObject.transform.DOMove(_upCameraPosition.transform.position, _player.CameraMoveSpeed);
        }

        private void CameraHoldDown(InputAction.CallbackContext context)
        {
            gameObject.transform.DOMove(_downCameraPosition.transform.position, _player.CameraMoveSpeed);
        }

        private void OnEnable()
        {
            _player.Input.Enable();
        }

        private void OnDisable()
        {
            _player.Input.Disable();
        }
    }
}
