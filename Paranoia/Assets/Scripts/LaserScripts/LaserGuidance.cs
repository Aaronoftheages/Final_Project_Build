using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGuidance : MonoBehaviour {

    public Transform pointAlpha;
    public Transform pointBeta;
    public float speed;

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.Lerp(pointAlpha.position, pointBeta.position, Mathf.Sin(Time.time * speed));
	}
}
