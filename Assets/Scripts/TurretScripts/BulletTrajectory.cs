using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrajectory : MonoBehaviour {

    /*
    public GameManager gm;
    public Player player;
    */
    public float speed= 5f;
    float timeLeft = 10.0f;
    //private Rigidbody rb;
    //public Vector3 direction = new Vector3(0, 0, 1); //x,y,z

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        /*
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("Player");

        if(gameControllerObject != null)
        {
            player = gameControllerObject.GetComponent<Player>();
        }
        else
        {
            Debug.Log("Game Manager cannot be located");
        }
        */
    }


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Timer();

    }

    public void Timer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
      
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Structure")
        {
            Debug.Log("Wall hit");
            Destroy(this.gameObject);
        }
    }//Enter
}
