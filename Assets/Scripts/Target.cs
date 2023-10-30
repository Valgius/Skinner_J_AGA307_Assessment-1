using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 50;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            health = health - 10;
            gameObject.GetComponent<Renderer>().material.color = Color.red;

            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
