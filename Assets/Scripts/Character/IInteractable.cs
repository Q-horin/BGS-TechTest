using BGS.DialogueSystem;

namespace BGS.Character
{
    public interface IInteractable
    {
        void Interact();
        void HandleResponse(DialogueAction action);
    }
}