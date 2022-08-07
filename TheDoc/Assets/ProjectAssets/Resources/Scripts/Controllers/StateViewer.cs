using ProjectAssets.Resources.Doc.Scripts.Model;
using TMPro;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class StateViewer : MonoBehaviour
    {
        [Inject] private Player _player;
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>(); 
        }

        private void Update()
        {
            _text.text = _player.IsFalling.ToString();
        }
    }
}