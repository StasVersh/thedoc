using System;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Models
{
    [Serializable]
    public class LayerColor
    {
        public string LayerName;
        public Color Color;

        public LayerColor(string layerName)
        {
            LayerName = layerName;
            Color = Color.white;
        }
    }
}