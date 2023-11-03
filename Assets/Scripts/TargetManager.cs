using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : Singleton<TargetManager>
{
    public enum TargetSize { Small, Medium, Large}

    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    public List<GameObject> enemies;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SpawnAtRandom();
    }

    void SpawnAtRandom()
    {
        int rndEnemy = Random.Range(0, enemyTypes.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(enemyTypes[rndEnemy], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
        enemies.Add(enemy);
    }

    public void KillTarget(GameObject _target)
    {
        if (enemies.Count == 0)
            return;

        Destroy(_target);
        enemies.Remove(_target);
    }

    private void OnEnable()
    {
        Target.OnTargetDie += KillTarget;
    }

    private void OnDisable()
    {
        Target.OnTargetDie += KillTarget;
    }
}
