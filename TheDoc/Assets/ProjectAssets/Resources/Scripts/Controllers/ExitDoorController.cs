using System;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class ExitDoorController : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Application.Quit();
                }
            }
        }
    }
}
