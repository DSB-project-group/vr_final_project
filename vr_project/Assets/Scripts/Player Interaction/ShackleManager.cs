////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author : Jeremy Almonte
//Created On : 10/10/2023
//Description : Handles shackles and possible interactions after all shackles are broken
////////////////////////////////////////////////////////////////////////////////////////////////////////using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackleManager : MonoBehaviour
{
    [SerializeField] private Shackle[] Shackles;

    [SerializeField] private bool[] IsBroken;
    
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject interactableGO;

    [SerializeField] private LoadScene loadScene;

    private void Start()
    {
        IsBroken = new bool[Shackles.Length];
        for(int i = 0; i >= Shackles.Length; i++)
        {
            IsBroken[i] = true;
            Shackles[i].SetID(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

            
    }


    public void SetBrokenShackle(int id)
    {
        IsBroken[id] = true;
        //loadScene.LoadNextScene();
    
         CheckIfAllBroken();
    }

    private bool CheckIfAllBroken(){

        
        if(IsBroken[0] == false || IsBroken[1] == false)
        {     
            return false;
        }
        

        Debug.Log("Interacting");
        Interact();
        return true;
    }

    private void Interact()
    {
        if (interactableGO.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }


    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
