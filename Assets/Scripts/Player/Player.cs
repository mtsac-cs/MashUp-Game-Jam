using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(RobotModel))]
public class Player : MonoBehaviour
{
    public static Player instance;

    [NonSerialized]
    public RobotModel robotModel; // all robot related code should go here

    [NonSerialized]
    public List<StatModel> stats;

    [NonSerialized]
    public PlayerMovement playerMovement;

    void Start()
    {
        instance = this;
        playerMovement = GetComponent<PlayerMovement>();
        robotModel = GetComponent<RobotModel>();
        
        InitPlayerStats();
    }

    private void InitPlayerStats()
    {
        if (stats is null)
        {
            stats = new List<StatModel>();
        }
        else
        {
            stats.Clear();
        }

        var health = new HealthStat().Init(robotModel.numScrewsPerBody);
        stats.Add(health);
    }
}