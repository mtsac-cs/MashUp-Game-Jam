using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [NonSerialized]
    public Player player;
    public Rigidbody2D rb;
    [Range(1,10)]
    public float moveSpeed = 2.5f;
    Animator animator;
    Vector2 moveDirection = Vector2.down;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
