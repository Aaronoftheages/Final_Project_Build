using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

    public TurretFOV fo;
    public TurretSound so;
    public BulletTrajectory bullet;
    public Transform barrel;
    public float fireVel = 35;
    public float fireRate = 100;

    #region sound effects
    public GameObject fireSound;
    #endregion



    void Update () {
        if (fo.isInFOV == true)
        {

            Shoot();
        }
        if (so.isInSound == true)
        {
            Shoot();
        }
        if (fo.isInFOV == false && so.isInSound == false)
        {
            fireSound.SetActive(false);
        }
    }

    public void Shoot()
    {
        fireSound.SetActive(true);
        BulletTrajectory newBullet = Instantiate(bullet, barrel.position, barrel.rotation) as BulletTrajectory;
        newBullet.SetSpeed(fireVel);
    }
}


