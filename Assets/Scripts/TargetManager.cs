using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using static UnityEngine.GraphicsBuffer;

public class TargetManager : Singleton<TargetManager>
{
    public enum TargetSize { Small, Medium, Large }

    public Transform[] spawnPoints;
    public GameObject[] targetTypes;

    public List<GameObject> targets;

    private void Start()
    {
        if (_GM.difficulty == Difficulty.Easy)
        {
            SpawnEasyTargets();
        }
        if (_GM.difficulty == Difficulty.Medium)
        {
            SpawnMediumTargets();
        }
        if (_GM.difficulty == Difficulty.Hard)
        {
            SpawnHardTargets();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SpawnAtRandom();

        //Change difficulty of targets
        if (Input.GetKeyDown("4"))
        {
            _GM.difficulty = Difficulty.Easy;
            _UI.UpdateDifficulty();
            ChangeTargetDifficulty();
        }

        if (Input.GetKeyDown("5"))
        {
            _GM.difficulty = Difficulty.Medium;
            _UI.UpdateDifficulty();
            ChangeTargetDifficulty();
        }

        if (Input.GetKeyDown("6"))
        {
            _GM.difficulty = Difficulty.Hard;
            _UI.UpdateDifficulty();
            ChangeTargetDifficulty();
        }

        if (Input.GetKeyDown(KeyCode.R))
            ChangeTargetDifficulty();
    }


    /// <summary>
    /// Original to spawn random targets at random spawnpoints.
    /// </summary>
    void SpawnAtRandom() 
    {
        int rndTarget = Random.Range(0, targetTypes.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        GameObject target = Instantiate(targetTypes[rndTarget], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
        targets.Add(target);
        ShowTargetCount();
    }

    /// <summary>
    /// Spawns single target type at random spawnpoint depending of difficulty
    /// </summary>
    void SpawnSingleAtRandom()
    {
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        if (_GM.difficulty == Difficulty.Easy)
        {
            GameObject target = Instantiate(targetTypes[2], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
            targets.Add(target);
        }
        if (_GM.difficulty == Difficulty.Medium)
        {
            GameObject target = Instantiate(targetTypes[1], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
            targets.Add(target);
        }
        if (_GM.difficulty == Difficulty.Hard)
        {
            GameObject target = Instantiate(targetTypes[0], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
            targets.Add(target);
        }
        ShowTargetCount();
    }
    /// <summary>
    /// Spawns Easy Targets
    /// </summary>
    void SpawnEasyTargets()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
           GameObject target = Instantiate(targetTypes[2], spawnPoints[i].position, spawnPoints[i].rotation);
           targets.Add(target);
        }
        ShowTargetCount();
    }

    /// <summary>
    /// Spawns Medium Targets
    /// </summary>
    void SpawnMediumTargets()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject target = Instantiate(targetTypes[1], spawnPoints[i].position, spawnPoints[i].rotation);
            targets.Add(target);
        }
        ShowTargetCount();
    }

    /// <summary>
    /// Spawns HArd Targets
    /// </summary>
    void SpawnHardTargets()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject target = Instantiate(targetTypes[0], spawnPoints[i].position, spawnPoints[i].rotation);
            targets.Add(target);
        }
        ShowTargetCount();
    }

    void ShowTargetCount()
    {
        _UI.UpdateTargetCount(targets.Count);
    }

    //Change targets to random target size. (WIP)
    public void ChangeTargetSize()
    {
        for(int i = 0; i < targets.Count; i++)
        {
            KillTargets(targets[0]);
        }
        SpawnAtRandom();
    }

    public void ChangeTargetDifficulty()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            KillTargets(targets[0]);
        }
        SpawnSingleAtRandom();
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    /// <summary>
    /// Kills a specific target
    /// </summary>
    /// <param name="_enemy"> The enemy we want to kill</param>
    public void KillTargets(GameObject _target)
    {
        if (targets.Count == 0)
            return;

        ShowTargetCount();

        Destroy(_target);
        targets.Remove(_target);
        ShowTargetCount();
    }

    /// <summary>
    /// Kills all enemies in our stage
    /// </summary>
    void KillAllTargets()
    {
        if (targets.Count == 0)
            return;

        for (int i = 0; i < targets.Count-1; i--)
        {
            KillTargets(targets[0]);
        }
    }

    private void OnEnable()
    {
        Target.OnTargetDie += KillTargets;
    }

    private void OnDisable()
    {
        Target.OnTargetDie += KillTargets;
    }
}
