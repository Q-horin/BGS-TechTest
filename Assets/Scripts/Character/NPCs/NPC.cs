using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Character
{
    public abstract class NPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private Collider2D _interactionCollider;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Interact();
            }
        }

        public virtual void Interact()
        {
            Debug.Log("Base NPC interacting");
        }
    }
}
//EOF.