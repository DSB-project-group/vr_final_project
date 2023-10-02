using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monster_status : MonoBehaviour
{
    [SerializeField] private float monster_health = 100f;
    private Animator am;
    private float health = 100f;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (health <= 0f)
            {
                am.SetTrigger("isDeath");
                agent.isStopped = true;
            }
            Debug.Log("monster get hit");
            am.SetBool("isGetHit", true);
            am.SetInteger("getHitIndex", Random.Range(0, 3));
            health -= 10f;
            am.SetFloat("monster_health", health);
        }
        am.SetBool("isGetHit" , false);
    }
}
