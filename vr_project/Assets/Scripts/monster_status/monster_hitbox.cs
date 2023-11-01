using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider bc;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    LoadScene loadScene;
    [SerializeField]
    private bool canKill = false;
    
    void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit the player");
            if(animator.GetBool("isAttack"))
            {
                if(canKill)
                loadScene.LoadNextScene();
                else{
                    loadScene.SceneToLoad(0);
                }
            }
        }
    }
}
