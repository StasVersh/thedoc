using System;
using UnityEngine;

namespace ProjectAssets.Resources.Doc.Scripts
{
    public class CameraController : MonoBehaviour
    {
        public Vector3 Offset;
        public float Velocity;
        public float MinDistance;
        public Transform Target;

        private void Start()
        {
            Target = GameObject.FindWithTag("Player").transform;
            transform.position = Target.position + Offset;
        }

        // Update is called once per frame
        void LateUpdate() {
            if (Target == null) {
                return;
            }

            var targetPos = Target.transform.position + Offset;

            if (Vector3.Distance(transform.position, targetPos) < MinDistance) {
                return;
            }
            var newPos = Vector3.Lerp(transform.position, targetPos, Velocity * Time.fixedDeltaTime);
            transform.Translate(transform.InverseTransformPoint(newPos));
        }
    }
}