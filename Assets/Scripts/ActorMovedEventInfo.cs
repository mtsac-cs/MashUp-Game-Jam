using UnityEngine;

public class ActorMovedEventInfo
{
    public Vector2 Direction { get; set; }
    public float Amount { get; set; }

    public ActorMovedEventInfo(Vector2 direction, float amount)
    {
        Direction = direction;
        Amount = amount;
    }
}