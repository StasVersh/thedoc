using System;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class PlayerDataController : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private float _faceDirection;
        [Header("Ability's")]
        [SerializeField] private bool _haveHover;
        [SerializeField] private bool _haveDash;
        [Header("Movement")] 
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [Header("Dash")]
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashDistance;
        [SerializeField] private float _dashHeight;
        [SerializeField] private float _dashRollback;
        [Header("Hover")]
        [SerializeField] private float _hoverMaxSpeed;
        [SerializeField] private float _hoverForce;
        [Header("Physics")]
        [SerializeField] private float _maxFallingSpeed;
        [SerializeField] private float _fallingStepValue;
        [Header("Particles")] 
        [SerializeField] private ParticleSystem _runParticles;
        [SerializeField] private ParticleSystem _fallParticles;
        [SerializeField] private ParticleSystem _jumpParticles;
        [SerializeField] private ParticleSystem _hoverParticles;
        [SerializeField] private ParticleSystem _dashParticles;
        [SerializeField] private ParticleSystem _dashWayParticles;
        [SerializeField] private PlayerSteamController _steamController;

        [Inject] private Player _player;

        private void OnEnable()
        {
            _player.FaceDirection = _faceDirection;
            UpdateData();
        }

        private void Update()
        {
            UpdateData();
        }

        private void UpdateData()
        {            
            _player.HaveHover = _haveHover;
            _player.HaveDash = _haveDash;
            
            _player.Speed = _speed;
            _player.JumpSpeed = _jumpSpeed;

            _player.DashSpeed = _dashSpeed;
            _player.DashDistance = _dashDistance;
            _player.DashHeight = _dashHeight;
            _player.DashRollback = _dashRollback;
            
            _player.HoverMaxSpeed = _hoverMaxSpeed;
            _player.HoverForce = _hoverForce;
            
            _player.MaxFallingSpeed = _maxFallingSpeed;
            _player.FallingStepValue = _fallingStepValue;
            
            _player.RunParticles = _runParticles;
            _player.FallParticles = _fallParticles;
            _player.JumpParticles = _jumpParticles;
            _player.HoverParticles = _hoverParticles;
            _player.DashParticles = _dashParticles;
            _player.DashWayParticles = _dashWayParticles;
            _player.SteamController = _steamController;
        }
    }
}