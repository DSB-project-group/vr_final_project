using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class monster_status : MonoBehaviour
{
    private Animator am;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            am.SetBool("isGetHit", true);
        }
    }
}
