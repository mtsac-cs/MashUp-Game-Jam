using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorMovement : MonoBehaviour
{
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
