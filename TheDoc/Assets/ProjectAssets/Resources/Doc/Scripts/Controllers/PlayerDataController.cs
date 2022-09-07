using System;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class PlayerDataController : MonoBehaviour
    {
        [Header("Movement")] 
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _fallingStepValue;
        [Header("Particles")] 
        [SerializeField] private ParticleSystem _dustRunParticles;
        [SerializeField] private ParticleSystem _dustFallParticles;
        [SerializeField] private PlayerSteamController _steamController;

        [Inject] private Player _player;

        private void OnEnable()
        {
            UpdateData();
        }

        private void Update()
        {
            UpdateData();
        }

        private void UpdateData()
        {
            _player.Speed = _speed;
            _player.JumpSpeed = _jumpSpeed;
            _player.FallingStepValue = _fallingStepValue;
            _player.DustRunParticles = _dustRunParticles;
            _player.DustFallParticles = _dustFallParticles;
            _player.SteamController = _steamController;
        }
    }
}