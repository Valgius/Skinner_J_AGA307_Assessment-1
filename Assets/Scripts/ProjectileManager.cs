using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : Singleton<ProjectileManager>
{
    public GameObject projectilePrefab;    //The projectile we wish to instantiate
    public GameObject[] projectileTypes;   //Array of projectile types

    public int damage;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            projectilePrefab = projectileTypes[0];
            damage = 20;
            _UI.UpdateProjectile();
        }

        if (Input.GetKeyDown("2"))
        {
            projectilePrefab = projectileTypes[1];
            damage = 40;
            _UI.UpdateProjectile();
        }

        if (Input.GetKeyDown("3"))
        {
            projectilePrefab = projectileTypes[2];
            damage = 60;
            _UI.UpdateProjectile();
        }
    }
}
