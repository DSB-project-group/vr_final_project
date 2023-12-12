using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyInteract : MonoBehaviour
{
    [SerializeField] private LoadScene loadScene;
    // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Key")
        {
            loadScene.LoadNextScene();
        }
    }
}
