using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.Model
{
    public class Player
    {
        public float Speed { get; set; }
        public float JumpSpeed { get; set; }
        public float DashStartSpeed { get; set; }
        public float DashBreakForce { get; set; }
        public float HoverMaxSpeed { get; set; }
        public float HoverForce { get; set; }
        public float MaxFallingSpeed { get; set; }
        public float FallingStepValue { get; set; }
        public bool CanJump { get; set; }
        public bool CanDash { get; set; }
        public bool IsFalling { get; set; }
        public bool HaveHover { get; set; }
        public bool HaveDash { get; set; }
        public InputMeneger Input { get; set; }
        public ParticleSystem RunParticles { get; set; }
        public ParticleSystem FallParticles { get; set; }
        public ParticleSystem JumpParticles { get; set; }
        public ParticleSystem HoverParticles { get; set; }
        public PlayerSteamController SteamController { get; set; }
        public PlayerController Controller { get; set; }
        public StateManager States { get; set; }
        public GameObject GameObject { get; set; }

        public Player(GameObject gameObject)
        {
            GameObject = gameObject;
            Input = new InputMeneger();
            Input.Enable();
        }
    }
}