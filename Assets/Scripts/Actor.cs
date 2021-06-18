using System;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [NonSerialized]
    public ActorMovement actorMovement;

    void Start()
    {
        actorMovement = gameObject.AddComponent<ActorMovement>();
    }

    void Update()
    {
        
    }
}
