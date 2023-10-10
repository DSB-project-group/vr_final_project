using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class patroll_state : StateMachineBehaviour
{
    float timer;
    Transform player;
    //float chaseR = 10f;
    List<Transform> PathPoints = new List<Transform>();
    NavMeshAgent agent;
    float walkSpeed = 2.4f;
    //onstateenter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        GameObject points = GameObject.FindGameObjectWithTag("paths");
        agent.speed = walkSpeed;
        foreach (Transform t in points.transform)
        {
            PathPoints.Add(t);
        }
        agent.SetDestination(PathPoints[Random.Range(0 , PathPoints.Count)].position);
    }

    //onstateupdate is called on each update frame between onstateenter and onstateexit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        timer += Time.deltaTime;
        if(timer > 8)
        {
            animator.SetBool("isPatrolling", false);
        }
    }

    //onstateexit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {

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
