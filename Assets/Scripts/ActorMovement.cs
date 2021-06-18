using System;
using UnityEngine;
using UnityEngine.Events;

public class ActorMovement : MonoBehaviour
{
    [NonSerialized]
    public UnityEvent onMove;

    // Start is called before the first frame update
    void Start()
    {
        onMove = new UnityEvent();
    }

    protected void OnMoved()
    {
        onMove?.Invoke();
    }
}
