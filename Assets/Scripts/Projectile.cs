using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 20;

    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        //Check to see if the collided object has the tag "Target"
        if (collision.collider.CompareTag("Target"))
        {
            //Change the collided objects material colour to red
            collision.collider.GetComponent<Renderer>().material.color = Color.red;
            //Destroy the collided object after 1 second
            Destroy(collision.collider.gameObject, 1f);
            //Destroy this gameobject
            Destroy(this.gameObject);
        }
    } */
}
