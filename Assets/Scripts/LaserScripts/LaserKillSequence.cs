using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserKillSequence : MonoBehaviour {

    public GameManager gm;
    public Player player;
    public int damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(other.gameObject);
            Debug.Log("Zap");
            if(player.shield > 0)
            {
                player.shield = player.shield - damage;
            }
            if(player.shield <= 0) {
                player.health = player.health - damage;
                Debug.Log("Player Health Equals = " + player.health);
            }
                
        }
    }

}
