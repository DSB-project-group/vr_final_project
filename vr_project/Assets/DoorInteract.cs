////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author : Jeremy Almonte
//Created On : 12/5/2023
//Description : Handles animated door interaction
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DoorInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip doorOpenSFX;
    [SerializeField] private AudioClip doorCloseSFX;
    private bool IsOpen = false;

    public void Interact()
    {
        IsOpen = !IsOpen;

        animator.SetBool("IsOpen", IsOpen);
        if(IsOpen)
            audioSource.PlayOneShot(doorOpenSFX, 0.25f);
        else
            audioSource.PlayOneShot(doorCloseSFX, 0.25f);
    }
}
