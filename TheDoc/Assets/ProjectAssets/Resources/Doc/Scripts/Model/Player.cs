using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.Model
{
    public class Player
    {
        public float Speed;
        public float JumpSpeed;
        public float CoyoteTime;
        public bool CanJump;
        public bool IsFalling;
        public float HorizontalDirection;
        public ParticleSystem DustRunParticles;
        public ParticleSystem DustFallParticles;
        public PlayerController Controller;
        public StateManager States;
        public GameObject GameObject;

        public Player(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}