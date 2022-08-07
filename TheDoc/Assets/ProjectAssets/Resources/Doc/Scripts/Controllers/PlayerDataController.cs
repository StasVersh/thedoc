using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class PlayerDataController : MonoBehaviour
    {
        [Header("Movement")] 
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _coyoteTime;
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
    }
}