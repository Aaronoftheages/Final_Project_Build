using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TurretMaster : MonoBehaviour
{
    public float speed;


    public GameObject cameraObjectScript; 

    public GameObject playerTarget;
    public GameObject turretTarget;
    public GameObject currentTarget;

   
    public TurretArea tArea;
    public TurretFOV tFOV;
    public TurretSound tSound;

    #region sound effects
    public GameObject patrol;
    public GameObject alert;
    #endregion



    // Update is called once per frame
    void Update()
    {
        resumePatrol();
        if (tArea.isInArea)
        {
 
        }
        //Player is not in Area and Field of Vision but not in Sound
        if (tArea.isInArea && tFOV.isInFOV && !tSound.isInSound)
        {
            playerSpotted();       
        }
        //Player is in Area and Sound
        if (tArea.isInArea && tSound.isInSound)
        {
            Debug.Log("In Sound, fire!");
            playerSpotted();
        }
        //Player is in Area 
        if (tArea.isInArea && !tFOV.isInFOV && !tSound.isInSound)
        {
            patrol.SetActive(false);
            alert.SetActive(true);
            resumePatrol();
        }
        if (!tArea.isInArea && !tFOV.isInFOV && !tSound.isInSound)
        {
            alert.SetActive(false);
            patrol.SetActive(true);
            resumePatrol();
        }
    }//update

    void playerSpotted()
    {
        alert.SetActive(false);
        currentTarget.transform.position = playerTarget.transform.position;
        Debug.Log("Player is in the Area & FOV ...[from Master Script]");
        

    }

    void resumePatrol()
    {
        currentTarget.transform.position = turretTarget.transform.position;
        Debug.Log("Player is in the Area & NOT in FOV ...[from Master Script]");
        
    }

}//TurretMaster
