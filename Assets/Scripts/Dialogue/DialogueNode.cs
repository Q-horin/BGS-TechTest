using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Dialogue
{
    [System.Serializable]
    public class DialogueNode
    {
        [SerializeField] public string ID;
        [TextArea(5,5)]
        [SerializeField] private string _text;
        [SerializeField] private string[] childNodes;
    }
}
//EOF.