using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class testing_ai : MonoBehaviour
{

    [SerializeField]private Transform goal;
    [SerializeField] private float runDistance = 10.0f;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isRunning = false;

    // Start is called before the first frame update\
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.position;
    
        float distanceToTarget = Vector3.Distance(transform.position, goal.position);

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

        float velocityMagnitude = agent.velocity.magnitude;
        anim.SetBool("isWalking", velocityMagnitude > 0.1f);
    }
}
