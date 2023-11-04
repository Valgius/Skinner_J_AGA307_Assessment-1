using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState { Title, Playing, Paused, GameOver }
    public enum Difficulty { Easy, Medium, Hard}

    public GameState gameState;
    public Difficulty difficulty;
    public int score = 0;
    int scoreMultiplier = 1;

    public float maxTime = 500;
    float timer = 30;

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

    private void Update()
    {
        if(gameState == GameState.Playing)
        {
            timer -= Time.deltaTime;
            timer = Mathf.Clamp(timer, 0, maxTime);
            _UI.UpdateTimer(timer);
        }
    }

    public void AddScore(int _points)
    {
        score += _points * scoreMultiplier;
        _UI.UpdateScore(score);
    }

    void OnTargetHit(GameObject _target)
    {
        int _score = _target.GetComponent<Target>().myScore;
        AddScore(_score);
        timer += 5.0f;
        _UI.UpdateTimer(timer);

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

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }
}
