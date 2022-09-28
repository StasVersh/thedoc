using System;
using ProjectAssets.Resources.Doc.Scripts.Model;
using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using EventHandler = ProjectAssets.Resources.Doc.Scripts.Utilitys.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class DoorEnterController : MonoBehaviour
    {
        [Inject] private Player _player;
        [SerializeField] private Locations _location;
        [SerializeField] private int _spawnPointIndex;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    _player.SpawnPointIndex = _spawnPointIndex;
                    EventHandler.LocationExit.Invoke(); 
                    SceneManager.LoadSceneAsync(_location.ToString());
                }
            }
        }
    }
}