using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetOrAddComponent<Rigidbody2D>();
        animator = gameObject.GetOrAddComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocityY",rb.velocity.y);
        animator.SetFloat("velocityX",rb.velocity.x);
    }
}
