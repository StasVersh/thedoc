using System.Collections;
using System.Collections.Generic;
using ProjectAssets.Resources.Doc.Scripts.Utilitys;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private float _jumpCoyoteTime;
        
        private KeyCode _jumpKeyCode = KeyCode.Space;
        private bool _isCanJump;
        
        private void Update()
        {
            if (Input.GetKeyDown(_jumpKeyCode))
            {
                InputHandler.Jump.Invoke();
                StartCoroutine(TryJump());
            }
            else if(_isCanJump)
            {
                InputHandler.Jump.Invoke();
            }
            if (Input.GetKeyUp(_jumpKeyCode))
            {
                InputHandler.StopJump.Invoke();
            }
            InputHandler.Moving.Invoke(Input.GetAxisRaw("Horizontal"));
        }
        
        private IEnumerator TryJump()
        {
            _isCanJump = true;
            yield return new WaitForSeconds(_jumpCoyoteTime);
            _isCanJump = false;
        }
    }
}
