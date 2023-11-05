using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;      //The object we wish to change
    public GameObject sphere2;     //The object we wish to change

    public bool onTrigger;         //Checks of the player is on the trigger.

    void FixedUpdate()
    {
        if (onTrigger == true)
        {
            //Create a reference to hold the info on what we hit
            RaycastHit hit;

            //A vector that gets our forward direction based on this game object
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hit, 10))
            {
                print(hit.collider.name);

                //if out hit returns a collider with the tag 'Sphere'
                if (hit.collider.CompareTag("Sphere"))
                {
                    // Change the collider gameobjects colour to blue
                    sphere2.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //change the spheres colour to green
            sphere.GetComponent<Renderer>().material.color = Color.green;
            //Increas the spheres scale by 0.01 on all axis
            sphere.transform.localScale = Vector3.one * 2f;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the spheres size back to 1
            sphere.transform.localScale = Vector3.one;
            //Change the spheres colour to white
            sphere.GetComponent<Renderer>().material.color = Color.white;

            sphere2.transform.localScale = Vector3.one;
            sphere2.GetComponent<Renderer>().material.color = Color.white;

            onTrigger = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                sphere2.transform.localScale = Vector3.one * 2f;
                sphere2.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}

