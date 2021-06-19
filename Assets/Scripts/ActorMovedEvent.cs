using UnityEngine;

public class ActorMovedEvent
{
    public Vector2 Direction { get; set; }
    public float Amount { get; set; }

    public ActorMovedEvent(Vector2 direction, float amount)
    {
        Direction = direction;
        Amount = amount;
    }
}