using UnityEngine;

public class ActorMovedEventInfo
{
    public Vector2 Direction { get; set; }
    public float Amount { get; set; } = -1;

    public ActorMovedEventInfo(Vector2 direction)
    {
        Direction = direction;
    }

    public ActorMovedEventInfo(Vector2 direction, float amount)
    {
        Direction = direction;
        Amount = amount;
    }
}