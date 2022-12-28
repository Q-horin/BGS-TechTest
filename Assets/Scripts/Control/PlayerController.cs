using UnityEngine;
using UnityEngine.Events;
using BGS.DialogueSystem;
using BGS.Character;

namespace BGS.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _interactiveCollider;
        [SerializeField] private float _movementSpeed;

        private IInteractable _interactable;
        private Vector2 _moveDir;
        float _xValue;
        float _yValue;

        private void OnCollisionEnter2D(Collision2D collision)
        {
             if (!collision.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)) { return; }
             _interactable = interactable;
            _interactable.PreInteraction();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (_interactable == null) { return; }
            _interactable.ExitInteraction();
            _interactable = null;
        }
        void Update()
        {
            HandleMovementInput();

            if (Input.GetKey(KeyCode.E))
            {
                if (_interactable == null) { return; }
                _interactable.Interact();
            }
        }

        private void HandleMovementInput()
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