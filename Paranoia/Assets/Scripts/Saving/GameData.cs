using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour {


    public int health;
    //public bool canExit;

    //Will set up player position in levels at a later point
    public float[] position;

    public GameData (GameManager gm)
    {
        //health = gm.PlayerHealth;
        //canExit = gm.canCompleteLevel;
    }
    
    /*
    public PlayerData(CharacterController player)
    {
        position = new float[3];

    }
    */
}
