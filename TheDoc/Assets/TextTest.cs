using System.Globalization;
using ProjectAssets.Resources.Doc.Scripts.Model;
using TMPro;
using UnityEngine;
using Zenject;

public class TextTest : MonoBehaviour
{
    [Inject] private Player _player;
    private void Start()
    {
        GetComponent<TMP_Text>().text = _player.Speed.ToString(CultureInfo.InvariantCulture);
    }
}
