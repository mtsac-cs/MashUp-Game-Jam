using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
    public UnityEvent OnInteract { get; }

    bool CanInteract();

    void Interact(GameObject owner, GameObject interactable);
}