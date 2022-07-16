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
        [SerializeField] private float raydistance;
        private Rigidbody2D _rigidbody;
        private GroundCheckController _groundChecker;
        private bool _onGround;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _groundChecker = transform.Find("GroundChecker").GetComponent<GroundCheckController>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space)) Jump();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2 (speed * Input.GetAxisRaw("Horizontal"), _rigidbody.velocity.y);
            _rigidbody.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed, ForceMode2D.Force);
            var ray = Physics2D.Raycast(transform.position, Vector2.down, raydistance, 3);
        }

        private void Jump()
        {
            //if (!_onGround) return;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
