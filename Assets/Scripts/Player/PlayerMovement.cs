using System;
using UnityEngine;

public class PlayerMovement : ActorMovement
{
    [NonSerialized]
    public Player player;
    public Rigidbody2D rb;

    [Range(1,10)]
    public float moveSpeed = 2.5f;

    Animator animator;
    Vector2 moveDirection = Vector2.down;


    void Start()
    {
        animator = gameObject.GetOrAddComponent<Animator>();
        player = gameObject.GetOrAddComponent<Player>();
        rb = gameObject.GetOrAddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }
    void CalculateMovement()
    {
        if(rb.velocity.magnitude<=.001f){
            rb.velocity = Vector2.zero;
        }

        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }
}
