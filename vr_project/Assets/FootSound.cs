using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSound : MonoBehaviour
{


    [SerializeField]
    private AudioClip[] clips;

    private AudioSource footstepSound;

    // Start is called before the first frame update
    private void Awake()
    {
        footstepSound = GetComponent<AudioSource>();
    }

    private void FootStepsEvent()
    {
        AudioClip clip = GetRandomClip();
        footstepSound.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
