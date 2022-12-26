using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.DialogueSystem;


namespace BGS.Character
{
    public abstract class NPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private Dialogue _dialogue;

        public virtual void HandleResponse(DialogueAction action)
        {
            
        }

        public virtual void Interact()
        {
            if (DialogueManager.Instance.Interacting) { return; }
            DialogueManager.Instance.HandleDialogue(_dialogue, this);
        }
    }
}
//EOF.