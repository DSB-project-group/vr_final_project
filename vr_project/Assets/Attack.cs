using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource AttackSound;

    // Start is called before the first frame update
    private void Awake()
    {
        AttackSound = GetComponent<AudioSource>();
    }

    private void MonsterAttackEvent()
    {
        AudioClip clip = GetRandomClip();
        AttackSound.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
