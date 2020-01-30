using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{

    public GameManager gm;
    public Player player;

    // Use this for initialization
    void Start()
    {

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
        {
            gm = gameControllerObject.GetComponent<GameManager>();
        }
        else
        {
            Debug.Log("Game Manager cannot be located");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.health < 100)
            {
                player.health = player.health + 25;
                Debug.Log("Player Heath is now at" + player.health);
                Destroy(this.gameObject);
            }
            if (player.health >= 100)
            {
                Debug.Log("You are at max Health");
            }

        }
    }
}
