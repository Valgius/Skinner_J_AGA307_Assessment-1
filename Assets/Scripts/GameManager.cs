using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum Difficulty { Easy, Medium, Hard}

    public Difficulty difficulty;
    public int score = 0;
    int scoreMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        switch(difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                break;
            case Difficulty.Medium:
                scoreMultiplier = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplier = 3;
                break;
        }
    }

    public void AddScore(int _points)
    {
        score += _points * scoreMultiplier;
    }

    void OnTargetHit(GameObject _target)
    {
        int _score = _target.GetComponent<Target>().myScore;
        AddScore(_score);
    }

    private void OnEnable()
    {
        Target.OnTargetHit += OnTargetHit;
        Target.OnTargetDie += OnTargetHit;
    }

    private void OnDisable()
    {
        Target.OnTargetHit -= OnTargetHit;
        Target.OnTargetDie -= OnTargetHit;
    }
}
