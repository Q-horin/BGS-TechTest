using UnityEngine;

namespace BGS.Dialogue
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] private DialogueNode[] _nodes;
    }
}
//EOF.