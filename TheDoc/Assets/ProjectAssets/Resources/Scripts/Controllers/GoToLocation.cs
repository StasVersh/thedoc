using System;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.SceneManagement;
using EventHandler = ProjectAssets.Resources.Doc.Scripts.Utilitys.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class GoToLocation : MonoBehaviour
    {
        [SerializeField] private Locations _location;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                EventHandler.LocationExit.Invoke();
                SceneManager.LoadSceneAsync(_location.ToString());
            }
        }
    }
}