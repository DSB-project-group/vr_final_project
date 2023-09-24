using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class testing_ai : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float runDistance = 10.0f;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isRunning = false;

    [SerializeField] LayerMask playerL, goalL;

    [SerializeField] private float attackR = 2.5f;
    private bool isAttacking = false;

    // Start is called before the first frame update\
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= attackR && !isAttacking)
        {
            agent.isStopped = true;
            anim.SetTrigger("attack");
            isAttacking = true;

            StartCoroutine(resumeWalk());
        }
        else {
            /*
            if (distanceToTarget <= runDistance && !isRunning)
            {
                isRunning = true;
                agent.speed = agent.speed * 2f;
                anim.SetBool("isRunning", true);
            }

            if (isRunning && agent.remainingDistance <= agent.stoppingDistance)
            {
                isRunning = false;
                agent.speed = agent.speed / 2f;
                anim.SetBool("isRunning", false);
            }
            */
            agent.isStopped = false;
            float velocityMagnitude = agent.velocity.magnitude;
            anim.SetBool("isWalking", velocityMagnitude > 0.1f);
            agent.destination = target.position;

        }
    }
    IEnumerator resumeWalk()
    {
        yield return new WaitForSeconds(2.0f);
        isAttacking = false;
        anim.ResetTrigger("attack");
    }
}
