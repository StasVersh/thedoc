using ProjectAssets.Resources.Doc.Scripts.Controllers;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.Model
{
    public class Player
    {
        public int SpawnPointIndex { get; set; }
        
        public float FaceDirection { get; set; }

        public float Speed { get; set; }
        public float JumpSpeed { get; set; }
        
        public float DashSpeed { get; set; }
        public float DashDistance { get; set; }
        public float DashHeight { get; set; }
        public float DashRollback { get; set; }
        
        public float HoverMaxSpeed { get; set; }
        public float HoverForce { get; set; }

        public float DoubleJumpSpeed { get; set; }
        
        public float HookingMaxSpeed { get; set; }
        public float HookingForce { get; set; }
        public float HookingJumpSpeed { get; set; }
        public float HookingSpeed { get; set; }

        public float MaxFallingSpeed { get; set; }
        public float FallingStepValue { get; set; }

        public bool CanJump { get; set; }
        public bool CanDash { get; set; }
        public bool CanDoubleJump { get; set; }
        public bool IsFalling { get; set; }
        public bool IsWallHit { get; set; }
        public bool IsLooking { get; set; } 

        public bool HaveHover { get; set; }
        public bool HaveDash { get; set; }
        public bool HaveDoubleJump { get; set; }
        public bool HaveHooking { get; set; }

        public ParticleSystem RunParticles { get; set; }
        public ParticleSystem FallParticles { get; set; }
        public ParticleSystem JumpParticles { get; set; }
        public ParticleSystem HoverParticles { get; set; }
        public ParticleSystem DashParticles { get; set; }
        public ParticleSystem DashWayParticles { get; set; }

        public InputMeneger Input { get; set; }
        public PlayerSteamController SteamController { get; set; }
        public PlayerController Controller { get; set; }
        public StateManager States { get; set; }
        public GameObject Prefab { get; set; }
        public GameObject GameObject { get; set; }

        public GameObject CameraTarget { get; set; }
        public GameObject UpCameraPosition { get; set; }
        public GameObject DownCameraPosition { get; set; }
        public float CameraMoveSpeed { get; set; }

        public Player(GameObject prefab)
        {
            Prefab = prefab;
            Input = new InputMeneger();
            Input.Enable();
        }
    }
}