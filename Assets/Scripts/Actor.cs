using System;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [NonSerialized]
    public List<StatModel> stats;

    [NonSerialized]
    public ActorMovement actorMovement;

    void Start()
    {
        stats = new List<StatModel>();
        actorMovement = gameObject.AddComponent<ActorMovement>();
    }
}