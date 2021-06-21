using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : StateMachineBehaviour
{
    Rigidbody2D rb;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        List<Node> path = GameObject.Find("A_").GetComponent<NodeGrid>().path;
        if (path.Count > 0)
        {
            if (Enemy.instance.transform.GetComponent<Health>().health > 75)
            {
                rb.AddForce((path[0].worldPosition - Enemy.instance.transform.position).normalized * 2 * Time.deltaTime);

            }
            else
            {
                rb.AddForce((path[0].worldPosition - Enemy.instance.transform.position).normalized * 4 * Time.deltaTime);

            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.parent.GetComponent<RangedWeapon>().EnemySplash(10);

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
