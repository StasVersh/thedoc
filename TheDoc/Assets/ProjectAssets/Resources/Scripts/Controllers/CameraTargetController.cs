using System;
using UnityEngine;
using DG.Tweening;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine.InputSystem;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class CameraTargetController : MonoBehaviour
    {
        [SerializeField] private GameObject _upCameraPosition;
        [SerializeField] private GameObject _idleCameraPosition;
        [SerializeField] private GameObject _downCameraPosition;
        
        [Inject] private Player _player;

        private InputMeneger _input;

        private void Awake()
        {
            _input = _player.Input;
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void OnCameraUp()
        {
            transform.DOMove(_upCameraPosition.transform.position, 1);
        }

        private void OnCameraDown()
        {
            transform.DOMove(_downCameraPosition.transform.position, 1);
        }

        private void ReturnToDefaultPosition()
        {
            transform.DOMove(_idleCameraPosition.transform.position, 1);
        }
    }
}
