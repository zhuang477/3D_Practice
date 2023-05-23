using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Sound : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    public AudioClip lightSwing;
    public AudioClip heavySwing;
    public AudioClip stab;
    public AudioClip Kick;

    void PlayLightSwing(){
        audioSource.PlayOneShot(lightSwing);
    }

    void PlayHeavySwing(){
        audioSource.PlayOneShot(heavySwing);
    }

    void PlayStab(){
        audioSource.PlayOneShot(stab);
    }

    void PlayKick(){
        audioSource.PlayOneShot(Kick);
    }
}
