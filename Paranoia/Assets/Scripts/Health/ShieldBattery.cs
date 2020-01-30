using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBattery : MonoBehaviour
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
            if (player.shield < 100)
            {
                player.shield = player.shield + 25;
                Debug.Log("Player Shield is now at" + player.shield);
                Destroy(this.gameObject);
            }
            if (player.shield >= 100)
            {
                Debug.Log("You are at max shield");
            }

        }
    }
}
