using System;
using System.Collections;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(Light2D))]
    public class LightningNoiseController : MonoBehaviour
    {
        [SerializeField] private float _noise;
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue;
        private Light2D _light;

        private void Start()
        {
            _light = GetComponent<Light2D>();
            //StartCoroutine(Noise());
        }

        private void Update()
        {
            _light.intensity += (float)Math.Sin(Time.time) / _noise;

            if (_light.intensity > _maxValue || _light.intensity < _minValue)
            {
                _light.intensity = (_maxValue + _minValue) / 2;
            }
        }

        private IEnumerator Noise()
        {
            while (true)
            {
                yield return new WaitForSeconds(_noise / 1000);
                _light.intensity = Random.Range(_minValue, _maxValue);
            }
        }
    }
}