using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using static TargetManager;

public class Target : MonoBehaviour
{

    //public PatrolType myPatrol;
    float baseSpeed = 1f;
    public float mySpeed = 1f;
    float moveDistance = 1000;

    int baseHealth = 100;
    int maxHealth;
    public int myHealth;
    public int myScore;
    float scaleFactor = 1;

    [Header("AI")]
    public TargetSize mySize;
    public Transform[] spawnPoints;
    public Transform moveToPos;     //Needed for all patrols
    Transform startPos;             //Needed for loop patrol movement
    Transform endPos;               //Needed for loop patrol movement
    bool reverse;                   //Needed for loop patrol movement
    //int patrolPoint = 0;            //Needed for Linear partol Movement


    private void Start()
    {
        switch (mySize)
        {
            case TargetSize.Small:
                myHealth = maxHealth = baseHealth / 2;
                mySpeed = baseSpeed * 2;
                myScore = 300;
                transform.localScale = new Vector3(1,(float)0.02,1) * scaleFactor / 2;
                break;
            case TargetSize.Medium:
                myHealth = maxHealth = baseHealth;
                mySpeed = baseSpeed;
                myScore = 200;
                transform.localScale = new Vector3(1, (float)0.02, 1) * scaleFactor;
                break;
            case TargetSize.Large:
                myHealth = maxHealth = baseHealth * 2;
                mySpeed = baseSpeed / 2;
                myScore = 100;
                transform.localScale = new Vector3(1, (float)0.02, 1) * scaleFactor *2;
                break;
        }

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.right * Time.deltaTime * mySpeed);
            yield return null;
        }
        transform.Rotate(Vector3.up * 180);
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(Move());
    }


    //private void OnCollisionEnter(Collision collision)
    // {
    //    if (collision.collider.CompareTag("Projectile"))
    //    {
    //        health = health - 10;
    //        gameObject.GetComponent<Renderer>().material.color = Color.red;
    //
    //        if (health == 0)
    //        {
    //            Destroy(this.gameObject);
    //        }
    //    }
    //}
}
