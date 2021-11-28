using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTerminal : MonoBehaviour
{
    #region Referances
    public GameManager gm;
    public Player player;
    #endregion

    #region UI elements
    public GameObject SaveorLoad;
    public GameObject Save;
    public GameObject Load;
    #endregion

    #region Sounds
    public AudioClip Actclick;
    private AudioSource source;
    public bool clipPlayed = false;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    #endregion


    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player Can Activate the Terminal
            Debug.Log("Player Can use the Save Terminal");
            gm.closetoSave = true;
            SaveorLoad.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player can't use the console
            Debug.Log("Player can't save Anymore");
            gm.closetoSave = false;
            SaveorLoad.SetActive(false);
            Save.SetActive(false);
            Load.SetActive(false);
        }
    }


    void OnTriggerStay(Collider other)
    {
        //Saving
        if (Input.GetKeyDown(KeyCode.Z))
        {
          SaveorLoad.SetActive(false);
          Save.SetActive(true);
            if (clipPlayed == false)
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(Actclick, vol);
                clipPlayed = true;
            }
            Debug.Log("Saving Data.");
          player.SavePlayer();
          Debug.Log("Game Saved.");
        }
        //Loading
        if (Input.GetKeyDown(KeyCode.L))
        {
          SaveorLoad.SetActive(false);
          Load.SetActive(true);
            if (clipPlayed == false)
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(Actclick, vol);
                clipPlayed = true;
            }
            Debug.Log("Loading Data.");
          player.LoadPlayer();
          Debug.Log("Game Loaded.");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

}
