using System;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class PlayerDataController : MonoBehaviour
    {
        [Header("Ability's")]
        [SerializeField] private bool _haveHover;
        [SerializeField] private bool _haveDash;
        [Header("Movement")] 
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _dashStartSpeed;
        [SerializeField] private float _dashBreakForce;
        [SerializeField] private float _hoverMaxSpeed;
        [SerializeField] private float _hoverForce;
        [SerializeField] private float _maxFallingSpeed;
        [SerializeField] private float _fallingStepValue;
        [Header("Particles")] 
        [SerializeField] private ParticleSystem _runParticles;
        [SerializeField] private ParticleSystem _fallParticles;
        [SerializeField] private ParticleSystem _jumpParticles;
        [SerializeField] private ParticleSystem _hoverParticles;
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
            _player.HaveHover = _haveHover;
            _player.HaveDash = _haveDash;
            _player.Speed = _speed;
            _player.DashStartSpeed = _dashStartSpeed;
            _player.DashBreakForce = _dashBreakForce;
            _player.JumpSpeed = _jumpSpeed;
            _player.HoverMaxSpeed = _hoverMaxSpeed;
            _player.HoverForce = _hoverForce;
            _player.MaxFallingSpeed = _maxFallingSpeed;
            _player.FallingStepValue = _fallingStepValue;
            _player.RunParticles = _runParticles;
            _player.FallParticles = _fallParticles;
            _player.JumpParticles = _jumpParticles;
            _player.HoverParticles = _hoverParticles;
            _player.SteamController = _steamController;
        }
    }
}