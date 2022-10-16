using System.Collections.Generic;
using System.Linq;
using ProjectAssets.Resources.Scripts.Models;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [ExecuteInEditMode]
    public class ColorSetterController : MonoBehaviour
    {
        [SerializeField] private List<LayerColor> _colorsLayers;
        private List<SpriteRenderer> _children = new List<SpriteRenderer>();
        private List<string> _layers = new List<string>();

        private void Update()
        {
            _children.Clear();
            _layers.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                var renderer = child.GetComponent<SpriteRenderer>();
                _children.Add(renderer);
                if(!_layers.Contains(renderer.sortingLayerName))
                {
                    _layers.Add(renderer.sortingLayerName);
                }
            }

            UpdateView();
        }

        private void UpdateView()
        {
            if(_children.Count != _layers.Count)
            {
                var list = _colorsLayers.Where(colorsLayer => !_layers.Contains(colorsLayer.LayerName)).ToList();
                foreach (var layerColor in list)
                {
                    _colorsLayers.Remove(layerColor);
                }
            }
            foreach (var layer in _layers)
            {
                var layerColor = new LayerColor(layer);
                var v = _colorsLayers.Where(color => color.LayerName == layer).ToList();
                var contOnLayer = v.Count;
                if(contOnLayer <= 1) _colorsLayers.Add(new LayerColor(layer));
                _colorsLayers.Add(layerColor);
                var layerList = _children.Where(spriteRenderer => spriteRenderer.sortingLayerName == layer);
                foreach (var spriteRenderer in layerList)
                {
                    spriteRenderer.color = layerColor.Color;
                }
            }
        }
    }
}