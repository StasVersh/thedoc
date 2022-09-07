using System.Collections;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts.Controllers
{
    public class PlayerSteamController : MonoBehaviour
    {
        [SerializeField] private float SteamDuration;
        [SerializeField] private float StartPauseDuration;
        [SerializeField] private float StopPauseDuration;

        private ParticleSystem _steamParticles;
        private IEnumerator _enumerator;

        private void Start()
        {
            _steamParticles = GetComponent<ParticleSystem>();
            _enumerator = SteamBreathCycle();
        }

        public void StartSteam()
        {
            StartCoroutine(_enumerator);
        }

        public void StopSteam()
        {
            StopCoroutine(_enumerator);
            _steamParticles.Stop();
        }

        private IEnumerator SteamBreathCycle()
        {
            while (true)
            {
                var duration = Random.Range(StartPauseDuration, StopPauseDuration);
                yield return new WaitForSeconds(duration);
                _steamParticles.Play();
                yield return new WaitForSeconds(SteamDuration);
                _steamParticles.Stop();
            }
        }
    }
}
