using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDoor : MonoBehaviour
{
    public GameManager gm;
    Animator animator;
    bool doorOpen;
    public AudioClip DoorSFX;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (gm.canCompleteLevel == true)
        {
            if (col.gameObject.tag == "Player")
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(DoorSFX);
                doorOpen = true;
                DoorControl("Open");
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(DoorSFX);
            doorOpen = false;
            DoorControl("Close");
        }
    }

    void DoorControl(string direction)
    {
        animator.SetTrigger(direction);

    }
}
