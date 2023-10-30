using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPadTwo : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
