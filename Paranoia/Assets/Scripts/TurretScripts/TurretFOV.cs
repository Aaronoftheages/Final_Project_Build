using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFOV : MonoBehaviour
{

    public bool isInFOV;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player in FOV");
            isInFOV = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player left FOV");
            isInFOV = false;
        }
    }

}
