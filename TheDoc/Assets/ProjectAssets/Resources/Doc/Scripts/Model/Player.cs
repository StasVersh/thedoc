using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.Model
{
    public class Player
    {
        public float Speed;
        public float JumpSpeed;
        public float FallingStepValue;
        public bool CanJump;
        public bool IsFalling;
        public InputMeneger Input;
        public ParticleSystem DustRunParticles;
        public ParticleSystem DustFallParticles;
        public PlayerSteamController SteamController;
        public PlayerController Controller;
        public StateManager States;
        public GameObject GameObject;

        public Player(GameObject gameObject)
        {
            GameObject = gameObject;
            Input = new InputMeneger();
            Input.Enable();
        }
    }
}