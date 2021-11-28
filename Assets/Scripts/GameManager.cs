using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    #region // Player Objects
    public GameObject player;
    //public Collider playerbody;
    public Vector3 playerPosition;
    public bool playerDead = false;
    #endregion

    #region //sound effects
    public AudioClip deathsound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public bool deathsoundPlayed = false;
    #endregion

    #region //Screen
    public GameObject deathscreen;
    public GameObject playerVitals;
    #endregion

    //Hostile Entity Managers
    public bool enemiesOnline = true;

    #region //Close Terminal States
    public bool closetoExit = false;
    public bool closetoShutdown = false;
    public bool closetoSave = false;
    #endregion

    //Level can be completed states
    #region Escape Conditions
    public bool canCompleteLevel = false;
    public GameObject[] LinkedGrid;
    public GameObject levelExit;
    #endregion


    #region //spawn Locations
    public Vector3 startSpawnPosition;
    public GameObject startSpawn;
    public Vector3 saveSpawnPosition;
    public GameObject saveSpawn;
    #endregion

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void start()
    {
        playerSpawn();
    }

    public void Update()
    {
        death();
        if(canCompleteLevel == true)
        {
            escape();
        }
    }


    public void playerSpawn()
    {
        playerPosition = startSpawnPosition;
        Instantiate(player.transform, playerPosition, Quaternion.identity);
    }

    public void escape()
    {
        for (int i = 0; i < LinkedGrid.Length; i++)
        {
            if (LinkedGrid[i].gameObject != null) LinkedGrid[i].gameObject.SetActive(false);
        }

    }

    public void death()
    {
        if (playerDead == true)
        {
            playerVitals.SetActive(false);
            deathscreen.SetActive(true);
            if(deathsoundPlayed != true)
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(deathsound, vol);
                deathsoundPlayed = true;
            }
            Debug.Log("You're dead");
            if(Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Reloading Level");
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }

}
