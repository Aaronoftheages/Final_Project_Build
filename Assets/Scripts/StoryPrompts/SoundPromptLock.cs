using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPromptLock : MonoBehaviour
{

    public AudioClip sound;
    public AudioSource source;
    public bool audioPlayed = false;
    public GameManager gm;

    // Start is called before the first frame update
    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (gm.canCompleteLevel == true)
        {
            if (other.gameObject.tag == "Player")
            {
                if (audioPlayed == false)
                {
                    source.PlayOneShot(sound);
                    audioPlayed = true;
                }
            }
        }
    }

}
