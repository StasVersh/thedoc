using System;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts
{
    public class GroundCheckController : MonoBehaviour
    {
        //[HideInInspector] 
        public bool OnGround;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ground")) OnGround = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Ground")) OnGround = false;
        }
    }
}
