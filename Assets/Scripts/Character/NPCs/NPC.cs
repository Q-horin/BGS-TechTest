using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.DialogueSystem;


namespace BGS.Character
{
    public abstract class NPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private Dialogue _dialogue;

        private void Start()
        {
            
        }
        public virtual void Interact()
        {
            DialogueManager.Instance.HandleDialogue(_dialogue);
            //string currentDialogue = _dialogue._nodes[0]._text;
            //Debug.Log(currentDialogue);
        }
    }
}
//EOF.