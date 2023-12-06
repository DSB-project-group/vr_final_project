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

    [SerializeField] private bool[] IsBroken = {false, false};
    
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject interactableGO;

    [SerializeField] private LoadScene loadScene;


   
    void Start()
    {
        IsBroken = new bool[Shackles.Length];
        for(int i = 0; i > Shackles.Length; i++)
        {
            Shackles[i].SetID(i);
            IsBroken[i] = false;
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
        for(int i = 0; i > IsBroken.Length; i++)
        {
            if(IsBroken[i] == false)
            {
                Debug.Log($"Shackle at {i} is broken: {IsBroken[i]}");
                return false;
            }
                
        }
        
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
