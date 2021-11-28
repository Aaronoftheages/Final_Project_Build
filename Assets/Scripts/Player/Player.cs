using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    #region //References
    public GameManager gm;
    public Image healthBar;
    public Image shieldBar;
    #endregion

    #region //Audio
    public AudioClip healthWarn;
    public AudioClip shieldWarn;
    private AudioSource source;
    public bool healthWarnPlayed = false;
    public bool shieldWarnPlayed = false;
    #endregion

    #region //Variables
    public int health = 100;
    public int shield = 100;
    public bool canComplete;
    #endregion

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        health = data.health;
        shield = data.shield;
        canComplete = data.canComplete;
    }

    public void Update()
    {
        LevelCheckPlayer();
        LevelCompleteTrigger();
        BarSet();
        Death();
        ResetSound();
    }

    public void FixedUpdate()
    {

        if (shieldWarnPlayed != true)
        {
            if (shield <= 25)
            {
                source.PlayOneShot(shieldWarn);
                shieldWarnPlayed = true;
            }
        }
        if (healthWarnPlayed != true)
        {
            if (health <= 25)
            {
                source.PlayOneShot(healthWarn);
                healthWarnPlayed = true;
            }
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {

            if (shield > 0)
            {
                Debug.Log("Take shielding off");
                shield = shield - 25;
                Debug.Log("Player shield is " + shield);
               
            }
            if (shield == 0)
            {
                Debug.Log("Take health off");
                health = health - 10;
                Debug.Log("Player health is " + health);
                
            }
        }
    }//Enter

    public void ResetSound()
    {
        if(health >25)
        {
            healthWarnPlayed = false;
        }
        if(shield >25)
        {
            shieldWarnPlayed = false;
        }
    }

    public void BarSet()
    {
        healthBar.fillAmount = health / 100f;
        shieldBar.fillAmount = shield / 100f;
    }

    public void Death()
    {
        if (health <= 0)
        {
            gm.playerDead = true;
        }
    }

    public void LevelCheckPlayer()
    {
        if(gm.canCompleteLevel == true)
        {
            canComplete = true;
        }
    }
    public void LevelCompleteTrigger()
    {
        if(canComplete == true)
        {
            gm.canCompleteLevel = true;
        }
    }

}



