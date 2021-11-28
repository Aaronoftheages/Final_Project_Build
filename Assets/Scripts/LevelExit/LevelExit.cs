using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    public GameManager gm;
    public bool finalLevel;

    private void Start()
    {
        Scene Scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is" + Scene.name);
    }

    void OnTriggerEnter(Collider other)
    {
        if (gm.canCompleteLevel == true)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("*Clink* The Door Unlocks");
                if (finalLevel == false)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                if (finalLevel == true)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

}
