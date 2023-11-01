using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackleManager : MonoBehaviour
{
    [SerializeField] private Shackle shackleRight;
    [SerializeField] private Shackle shackleLeft;
    

    [SerializeField] private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shackleLeft.getHasTeared() && shackleRight.getHasTeared())
            return;
            //TODO: do stuff.

            
    }


    public AudioSource GetAudioSource()
    {
        return audioSource;
    }


    
}
