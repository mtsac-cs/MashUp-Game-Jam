using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : ActorMovement
{
    [NonSerialized]
    public Player player;

    [NonSerialized]
    public Rigidbody2D rb;

    [Range(1,10)]
    public float moveSpeed = 2.5f;

    Animator animator; // move this to RobotModel?
    Vector2 moveDirection = Vector2.down;


    void Start()
    {
        animator = gameObject.GetOrAddComponent<Animator>();
        player = gameObject.GetOrAddComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
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
