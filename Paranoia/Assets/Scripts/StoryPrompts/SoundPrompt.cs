using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPrompt : MonoBehaviour
{

    public AudioClip sound;
    public AudioSource source;
    public bool audioPlayed = false;

    // Start is called before the first frame update
    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(audioPlayed == false)
            {
                source.PlayOneShot(sound);
                audioPlayed = true;
            }
        }
    }

}
