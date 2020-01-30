using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int health;
    public int shield;
    public bool canComplete;

    public PlayerData (Player player)
    {
        health = player.health;
        shield = player.shield;
        canComplete = player.canComplete;
    }
}
