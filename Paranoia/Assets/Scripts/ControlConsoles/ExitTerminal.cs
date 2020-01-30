using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTerminal : MonoBehaviour
{

    public GameManager gm;

    #region UI Elements
    public GameObject PNotActive;
    public GameObject PActive;
    #endregion

    #region Sounds
    public AudioClip Actclick;
    private AudioSource source;
    public bool clipPlayed = false;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    #endregion

    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gm.canCompleteLevel == false)
            {
                PNotActive.SetActive(true);
            }
            if(gm.canCompleteLevel == true)
            {
                PActive.SetActive(true);
            }
            Debug.Log("Player Can use the Terminal");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(gm.canCompleteLevel == false)
            {
                PNotActive.SetActive(false);
            }
            if (gm.canCompleteLevel == true)
            {
                PActive.SetActive(false);
            }
            Debug.Log("Player left Area");
        }
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        //if (gm.closetoExit == true)
        // {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("You may now exit.");
                PNotActive.SetActive(false);
                PActive.SetActive(true);
                gm.canCompleteLevel = true;
                if (clipPlayed == false)
                {
                    float vol = Random.Range(volLowRange, volHighRange);
                    source.PlayOneShot(Actclick, vol);
                    clipPlayed = true;
                }
            }
        }
        // }
        //}
    }

}
