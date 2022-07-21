using System;
using TMPro;
using UnityEngine;
using EventHandler = ProjectAssets.Resources.Doc.Scripts.Utilitys.EventHandler;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class StateViewer : MonoBehaviour
    {
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            EventHandler.StateChanging.AddListener(UpdateUI);
        }

        private void UpdateUI(string log)
        {
            _text.text = log;
        }
    }
}