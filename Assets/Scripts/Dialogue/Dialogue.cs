using UnityEngine;

namespace BGS.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "BGS/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] public DialogueNode[] _nodes;
    }
}
//EOF.