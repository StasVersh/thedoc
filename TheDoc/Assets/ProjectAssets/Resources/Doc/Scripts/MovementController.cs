using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectAssets.Resources.Doc.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.A)) Move(Vector2.left);
            if(Input.GetKey(KeyCode.D)) Move(Vector2.right);
            if(Input.GetKeyDown(KeyCode.Space)) Jump();
        }

        private void Move(Vector2 derection)
        {
            transform.Translate(derection * speed);
        }
        private void Jump()
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
