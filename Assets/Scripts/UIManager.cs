using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text targetCountText;
    public TMP_Text difficultyText;
    public TMP_Text projectileText;

    private void Start()
    {
        UpdateScore(0);
        UpdateTimer(0);
        UpdateTargetCount(0);
        UpdateDifficulty();
        UpdateProjectile();
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateTimer(float _timer)
    {
        timerText.text = _timer.ToString("F2"); //F2 = amount of decimals
        timerText.color = _timer < 10f ? Color.red : Color.black;
    }

    public void UpdateTargetCount(int _count)
    {
        targetCountText.text = "Target Count: " + _count.ToString();
    }

    public void UpdateDifficulty()
    {
        difficultyText.text = "Difficulty: " + _GM.difficulty.ToString();
    }

    public void UpdateProjectile()
    {
        projectileText.text = "Projectile: " + _PM.projectilePrefab.ToString();
    }
}
