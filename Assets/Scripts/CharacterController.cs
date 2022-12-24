using UnityEngine;

namespace BGS.Controller
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _movementSpeed;

        private Vector2 _moveDir;
        float _xValue;
        float _yValue;

        void Update()
        {
            _xValue = 0f;
            _yValue = 0f;

            if (Input.GetKey(KeyCode.D))
            {
                _xValue = 1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                _xValue = -1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _yValue = -1f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                _yValue = 1f;
            }

            _moveDir = new Vector2(_xValue, _yValue).normalized;
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = _moveDir * _movementSpeed;
        }
    }
}
//EOF.