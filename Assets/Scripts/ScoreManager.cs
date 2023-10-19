using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string PLAYERPREFS_HIGHSCORE = "HighScore";
    public static ScoreManager Instance { get; private set; }
    public event EventHandler OnScoreChanged;
    public event EventHandler OnNewHighScore;
    private int _score;
    private int highScore;

    private void Awake()
    {
        Instance = this;
        highScore = GetHighScore();
        
    }
    
    private int GetScoreFromCubeNumber(int cubeNumber)
    {
        return cubeNumber switch
        {
            2 => 50,
            4 => 70,
            8 => 100,
            16 => 120,
            32 => 140,
            64 => 160,
            128 => 180,
            256 => 200,
            512 => 220,
            1024 => 240,
            2048 => 260,
            4096 => 280,
            _ => 0
        };
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetHighScore()
    {
        highScore = PlayerPrefs.GetInt(PLAYERPREFS_HIGHSCORE, 0);
        return highScore;
    }

    public void SetHighScore(int score)
    {
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt(PLAYERPREFS_HIGHSCORE, score);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt(PLAYERPREFS_HIGHSCORE, highScore);
            PlayerPrefs.Save();
        }
    }

    public void SetScore(int value)
    {
        _score = value;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    private void AddScore(int value)
    {
        _score += value;
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddScore(Cube cube)
    {
        int score = GetScoreFromCubeNumber(cube.cubeNumber);
        AddScore(score);
    }
    
}
