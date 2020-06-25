using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClickSound()
    {
        audioSource.PlayOneShot(clip);
    }
}
