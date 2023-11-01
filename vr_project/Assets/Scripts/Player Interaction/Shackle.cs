////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author : Jeremy Almonte
//Created On : 10/9/2023
//Description : Handles creating a shackle to bind the players hands using a line renderer
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shackle : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform tetherPoint;

    [SerializeField] private float tearDistance = 1f;
    [SerializeField] private float tetherDistance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ropeStretch;
    [SerializeField] private AudioClip ropeRip;
    private bool isPlayingStretchAudio;
    private bool isPlayingRipAudio;


    private float tempDistance = 0f;


    
    private bool hasTeared = false;

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasTeared)
            return;
        

        checkTear();

        if(audioSource.isPlaying == false)
            isPlayingStretchAudio = false;

        if(tempDistance != tetherDistance && !isPlayingStretchAudio)
        {
            isPlayingStretchAudio = true;
            audioSource.PlayOneShot(ropeStretch, 0.15f);
        }

        line.SetPosition(0, hand.position);
        line.SetPosition(1, tetherPoint.position);
        
    }

    public void checkTear()
    {
        tetherDistance = Vector3.Distance(hand.position, tetherPoint.position); //Check how far is the hand from the tether
        if (tetherDistance > tearDistance) // compare distance to tear point
            TearShackle(); 
    }

    public void TearShackle()
    {
        hasTeared = true;
        line.enabled = false; // disables the line component
        if(isPlayingStretchAudio)
            audioSource.Stop();
            
        audioSource.PlayOneShot(ropeRip, 0.15f);
        //TODO: add rope break SFX and VFX
    }

    public bool getHasTeared()
    {
        return hasTeared;
    }
}
  