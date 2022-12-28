using BGS.DialogueSystem;

namespace BGS.Character
{
    public interface IInteractable
    {
        void Interact();

        void PreInteraction();
        void ExitInteraction();
        void HandleResponse(DialogueAction action);
    }
}