using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.UI;

namespace BGS.DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField] private DialogueUIManager _dialogueUI;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        public void HandleDialogue(Dialogue dialogue)
        {
            _dialogueUI.EnableDialogueUI(true);
            _dialogueUI.SetDialogueText(dialogue._nodes[0]._text);
        }
    }
}
//EOF.