using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : GameBehaviour
{
    //public GameObject projectilePrefab;    //The projectile we wish to instantiate
    public float projectileSpeed = 1000;   //The speed that out projectile fires at
    public Transform firingPoint;          //The point at which the projectile will fire from

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Create a reference to hold our instantiated object
            GameObject projectileInstance;
            //Instantiate our projectile prefab at the fireing points position and rotation
            projectileInstance = Instantiate(_PM.projectilePrefab, firingPoint.position, firingPoint.rotation);
            //Get the rigidbody component of the projectile and add force to 'fire' it
            projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);
            //Destroy our projection after 5 seconds
            Destroy(projectileInstance, 5);
        }
    }
}
