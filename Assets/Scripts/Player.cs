using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public static Player instance;
    public PlayerMovement playerMovement;

    void Start()
    {
        instance = this;
        playerMovement = GetComponent<PlayerMovement>();
    }    
}