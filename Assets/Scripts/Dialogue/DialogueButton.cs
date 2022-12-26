using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BGS.UI;
using TMPro;

namespace BGS.DialogueSystem
{
    public class DialogueButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        private DialogueAction _dialogueAction;
        private DialogueUIManager _dialogueUIManager;

        public void InitConfiguration(DialogueAction action)
        {
            _dialogueAction = action;
            _buttonText.text = action.Text;
        }

        public void HandleClick()
        {
            _dialogueUIManager = FindObjectOfType<DialogueUIManager>();
            _dialogueUIManager.HandleResponse(_dialogueAction);
        }
    }
}
//EOF.