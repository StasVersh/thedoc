using ProjectAssets.Resources.Doc.Scripts.Installers;
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
            var fullState = _player.States._stateMachine.CurrentState.ToString();
            var lenght = fullState.Length - 1;
            _text.text = _player.CanDoubleJump.ToString();
        }
    }
}