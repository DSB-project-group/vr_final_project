using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject Ar_door;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = Ar_door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("lever")){
            anim.SetBool("Is_level_Pull", true);
        }
    }
}
