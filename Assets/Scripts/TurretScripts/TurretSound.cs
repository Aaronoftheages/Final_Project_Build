using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSound : MonoBehaviour
{

    public bool isInSound;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Debug.Log("Player in Sound Area");
            isInSound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player left  Sound Area");
            isInSound = false;
        }
    }

}
