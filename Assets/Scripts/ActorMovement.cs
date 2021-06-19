using System;
using UnityEngine;
using UnityEngine.Events;

public class ActorMovement : MonoBehaviour
{
    [NonSerialized]
    public UnityEvent<ActorMovedEvent> onMove;

    // Start is called before the first frame update
    void Start()
    {
        onMove = new UnityEvent<ActorMovedEvent>();
    }

    protected void OnMoved(Vector2 direction, float amount)
    {
        onMove?.Invoke(new ActorMovedEvent(direction, amount));
    }

    protected string GetDirectionName(Vector2 direction)
    {
        string directionName = "";

        if (direction == Vector2.up)
        {
            directionName = "Up";
        }
        else if (direction == Vector2.down)
        {
            directionName = "Down";
        }
        else if (direction == Vector2.left)
        {
            directionName = "Left";
        }        
        else if (direction == Vector2.right)
        {
            directionName = "Right";
        }

        return directionName;
    }
}
