using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walk_state : StateMachineBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private float walkSpeed = 2.4f;
    private float attackRange = 2.5f;
    private int monster_current_health;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;
        monster_current_health = animator.GetInteger("monster_health");
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);

        float dis = Vector3.Distance(player.position, animator.transform.position);

        if(dis > 10)
        {
            animator.SetBool("isWalking" , false);
        }

        if(dis <= attackRange)
        {
            animator.SetBool("isAttack", true);
            animator.SetInteger("attackIndex", Random.Range(0,2));
        }

        // if taking damage
        /*
        if(){
        animator.SetBool("isGetHit", true);
            animator.SetInteger("getHitIndex", Random.Range(0,3));
        }
        */

        if(monster_current_health <= 30)
        {
            animator.SetTrigger("IsRunning");
            animator.SetBool("stopRunning", false);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
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
