using UnityEngine;

namespace BGS.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] public DialogueNode[] _nodes;
    }
}
//EOF.