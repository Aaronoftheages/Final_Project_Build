using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial: https://www.youtube.com/watch?v=IX-kgWfecn4

public class LaserScript : MonoBehaviour {

    //Referance to two point to draw line
    public Transform startEmitter;
    public Transform endEmitter;

    //Referance to line renderer
    LineRenderer laserBeam;

	// Use this for initialization
	void Start () {
        laserBeam = GetComponent<LineRenderer>();
        laserBeam.SetWidth(.2f, .2f);

	}
	
	// Update is called once per frame
	void Update ()
    {
            laserBeam.SetPosition(0, startEmitter.position);
            laserBeam.SetPosition(1, endEmitter.position);
    }
}
