using System;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class GoToLocation : MonoBehaviour
    {
        [SerializeField] private Locations _location;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                SceneManager.LoadSceneAsync(_location.ToString());
            }
        }
    }
}