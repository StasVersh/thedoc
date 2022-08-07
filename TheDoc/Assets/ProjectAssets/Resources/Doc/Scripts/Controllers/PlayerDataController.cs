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
        [SerializeField] private float _coyoteTime;
        [SerializeField] private PlayerInput _input;
        [Header("Particles")] 
        [SerializeField] private ParticleSystem _dustRunParticles;
        [SerializeField] private ParticleSystem _dustFallParticles;

        [Inject] private Player _player;

        private void OnEnable()
        {
            _player.Speed = _speed;
            _player.JumpSpeed = _jumpSpeed;
            _player.CoyoteTime = _coyoteTime;
            _player.DustRunParticles = _dustRunParticles;
            _player.DustFallParticles = _dustFallParticles;
        }

        private void Start()
        {
            
        }
    }
}