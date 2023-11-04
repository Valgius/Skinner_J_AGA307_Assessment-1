using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : Singleton<TargetManager>
{
    public enum TargetSize { Small, Medium, Large}

    public Transform[] spawnPoints;
    public GameObject[] targetTypes;

    public List<GameObject> targets;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SpawnAtRandom();
    }

    void SpawnAtRandom()
    {
        int rndTarget = Random.Range(0, targetTypes.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        GameObject target = Instantiate(targetTypes[rndTarget], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
        targets.Add(target);
        ShowTargetCount();
    }

    void ShowTargetCount()
    {
        _UI.UpdateTargetCount(targets.Count);
    }

    public void KillTarget(GameObject _target)
    {
        if (targets.Count == 0)
            return;

        Destroy(_target);
        targets.Remove(_target);
        ShowTargetCount();
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
