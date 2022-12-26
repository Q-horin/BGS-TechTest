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
        [SerializeField] private GameObject _uiContainer;
        
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
            _uiContainer.SetActive(enable);
        }
    }
}
//EOF.