using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : Singleton<ProjectileManager>
{
    public GameObject projectilePrefab;    //The projectile we wish to instantiate
    public GameObject[] projectileTypes;   //Array of projectile types

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            projectilePrefab = projectileTypes[0];
            _UI.UpdateProjectile();
        }

        if (Input.GetKeyDown("2"))
        {
            projectilePrefab = projectileTypes[1];
            _UI.UpdateProjectile();
        }

        if (Input.GetKeyDown("3"))
        {
            projectilePrefab = projectileTypes[2];
            _UI.UpdateProjectile();
        }
    }
}
