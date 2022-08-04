using System;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class WallDetectorController : MonoBehaviour
    {
        //[HideInInspector]
        public bool Value;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Ground"))
            {
                Value = true;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Ground"))
            {
                Value = false;
            }
        }
    }
}
