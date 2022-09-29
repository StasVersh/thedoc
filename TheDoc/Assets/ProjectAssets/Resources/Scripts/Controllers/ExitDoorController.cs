using System;
using ProjectAssets.Resources.Doc.Scripts.Model;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class ExitDoorController : MonoBehaviour
    {
        [SerializeField] private GameObject _pressedInterectiveButton;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _pressedInterectiveButton.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _pressedInterectiveButton.SetActive(false);
            }
        }

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
