using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class InteractionObserver : MonoBehaviour
{
    private bool onTriggerEnter;
    private bool onTriggerExit;
    private bool onTriggerStay;

    public InteractionObserver Init(bool onTriggerEnter = true, bool onTriggerExit = false, bool onTriggerStay = false)
    {
        this.onTriggerEnter = onTriggerEnter;
        this.onTriggerExit = onTriggerExit;
        this.onTriggerStay = onTriggerStay;

        return this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onTriggerEnter)
            OnTrigger(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (onTriggerStay)
            OnTrigger(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onTriggerExit)
            OnTrigger(collision);
    }

    private void OnTrigger(Collider2D collision)
    {
        if (collision.gameObject.HasComponent<IInteractable>(out var itemDrop))
        {
            if (itemDrop.CanInteract())
                itemDrop.Interact(gameObject, collision.gameObject);
        }
    }
}