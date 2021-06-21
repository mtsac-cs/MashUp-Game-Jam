using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public NodeGrid pathfinding;
    public GameObject animatorHolder;
    public float dashCD = 3f;
    public float jumpCD = 7f;
    float timeSinceJump = 0;
    float timeSinceDash = 0;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = animatorHolder.GetComponent<Animator>();
        pathfinding = GameObject.Find("A_").GetComponent<NodeGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("DistanceFromPlayer", (transform.position - Player.instance.transform.position).magnitude);
        if (Time.time - timeSinceDash > dashCD)
        {
            animator.SetTrigger("SlimeDash");
        }
        if (Time.time - timeSinceJump > jumpCD)
        {
            animator.SetTrigger("JumpAttack");
        }
    }
    public List<Node> GetPath()
    {
        return pathfinding.path;
    }
}
