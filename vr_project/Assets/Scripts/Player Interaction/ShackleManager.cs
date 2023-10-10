using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackleManager : MonoBehaviour
{
    [SerializeField] private Shackle shackleRight;
    [SerializeField] private Shackle shackleLeft;
    


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


    
}
