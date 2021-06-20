using System;
using UnityEngine;
using UnityEngine.Events;

public class ActorMovement : MonoBehaviour
{
    [NonSerialized]
    public UnityEvent<ActorMovedEventInfo> onMove;

    // Start is called before the first frame update
    void Awake()
    {
        onMove = new UnityEvent<ActorMovedEventInfo>();
    }

    protected void OnMoved(Vector2 direction, float amount)
    {
        onMove?.Invoke(new ActorMovedEventInfo(direction, amount));
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
