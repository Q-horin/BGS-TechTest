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
        [SerializeField] private Animator _animator;

        private IInteractable _interactable;
        private Vector2 _moveDir;
        float _xValue;
        float _yValue;
        bool _isIdle;
        private bool _enableController = true;

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
            if(!_enableController) { return; }

            HandleMovementInput();

            if (Input.GetKey(KeyCode.E))
            {
                if (_interactable == null) { return; }
                _interactable.Interact();
            }
        }

        public void EnableController(bool enable)
        {
            _enableController = enable;
        }
        public void ReplaceRuntimeAnimatorController(AnimatorOverrideController aoc)
        {
            _animator.runtimeAnimatorController = aoc;
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
            _isIdle = _xValue == 0 && _yValue == 0;

            _moveDir = new Vector2(_xValue, _yValue).normalized;
        }

        private void FixedUpdate()
        {
            if (_isIdle)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _animator.SetBool("isMoving", false);
                return;
            }
            else if (!_isIdle)
            {
                _rigidbody2D.velocity = _moveDir * _movementSpeed;
                _animator.SetBool("isMoving", true);
                _animator.SetFloat("horizontalMovement", _moveDir.x);
                _animator.SetFloat("verticalMovement", _moveDir.y);
            }
        }
    }
}
//EOF.