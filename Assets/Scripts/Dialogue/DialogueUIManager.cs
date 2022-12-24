using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BGS.UI
{
    public class DialogueUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private Button[] _dialogueButtons;
        
        public void SetDialogueText(string dialogue)
        {
            _dialogueText.text = dialogue;
        }

        public void CloseDialogueUI()
        {
            EnableDialogueUI(false);
        }
        public void EnableDialogueUI(bool enable)
        {
            this.gameObject.SetActive(enable);
        }

        public void SetPosibleAnswers(string[] answers)
        {

        }
    }
}
//EOF.