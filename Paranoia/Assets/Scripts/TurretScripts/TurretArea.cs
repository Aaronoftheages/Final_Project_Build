using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretArea : MonoBehaviour {

    public bool isInArea;

    void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered Area");
            isInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player left Area");
            isInArea = false;
        }
    }

}
