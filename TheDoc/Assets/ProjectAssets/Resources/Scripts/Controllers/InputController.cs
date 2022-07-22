using System.Collections.Generic;
using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {
        private KeyCode _jumpKeyCode = KeyCode.Space;
        
        private void Update()
        {
            if (Input.GetKeyDown(_jumpKeyCode))
            {
                InputHandler.Jump.Invoke();
            }
            if (Input.GetKeyUp(_jumpKeyCode))
            {
                InputHandler.StopJump.Invoke();
            }
            InputHandler.Moving.Invoke(Input.GetAxisRaw("Horizontal"));
        }
    }
}
