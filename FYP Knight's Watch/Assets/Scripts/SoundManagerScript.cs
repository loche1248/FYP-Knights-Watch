//Resources - https://www.youtube.com/watch?v=8pFlnyfRfRc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, slash1Sound, slash2Sound, jumpSound, moveSound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("Hit");
        slash1Sound = Resources.Load<AudioClip>("Slash1");
        slash2Sound = Resources.Load<AudioClip>("Slash2");
        jumpSound = Resources.Load<AudioClip>("Jump");
        moveSound = Resources.Load<AudioClip>("Footstep");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Hit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "Slash1":
                audioSrc.PlayOneShot(slash1Sound);
                break;
            case "Slash2":
                audioSrc.PlayOneShot(slash2Sound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "Footstep":
                audioSrc.PlayOneShot(moveSound);
                break;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
