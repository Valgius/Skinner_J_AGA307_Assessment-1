using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public enum GameState { Title, Playing, Paused, GameOver }
    public enum Difficulty { Easy, Medium, Hard}

    public GameState gameState;
    public Difficulty difficulty;
    public int score = 0;
    int scoreMultiplier = 1;


    public float maxTime = 30;
    float timer = 30;

    public Image timerFill;

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
            UpdateTimerBar(timer, maxTime);
        }
    }

    public void UpdateTimerBar(float _time, float _maxTime)
    {
        timerFill.fillAmount = MapTo01(_time, 0, _maxTime);
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

    public void ChangeDifficulty(int _difficulty)
    {
        difficulty = (Difficulty)_difficulty;
    }

}
