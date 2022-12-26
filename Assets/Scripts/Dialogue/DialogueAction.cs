using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.DialogueSystem
{   
    [System.Serializable]
    public class DialogueAction
    {
        [SerializeField] public string Text;
        [SerializeField] private bool _needsResponse;
        [SerializeField] private bool _endsDialogue;

        public bool NeedsResponse => _needsResponse;
        public bool EndsDialogue => _endsDialogue;
    }
}
//EOF.