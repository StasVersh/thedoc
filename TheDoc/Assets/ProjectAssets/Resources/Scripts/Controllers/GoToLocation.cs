using ProjectAssets.Resources.Doc.Scripts.Values;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class GoToLocation : MonoBehaviour
    {
        [SerializeField] private Locations _location;
        [SerializeField] private GameObject _darkScreen;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                TurnOnDarkScreen();
                SceneManager.LoadSceneAsync(_location.ToString());
                
            }
        }

        private void TurnOnDarkScreen()
        {
            _darkScreen.SetActive(true);
        }
    }
}