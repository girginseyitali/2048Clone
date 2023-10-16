using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public event EventHandler OnScoreChanged;
    private int _score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }
    
    private int GetScoreFromCubeNumber(int cubeNumber)
    {
        switch (cubeNumber)
        {
            case 2:
                return 50;
                break;
            case 4:
                return 70;
                break;
            case 8:
                return 100;
                break;
            case 16:
                return 120;
                break;
            case 32:
                return 140;
                break;
            case 64:
                return 160;
                break;
            case 128:
                return 180;
                break;
            case 256:
                return 200;
                break;
            case 512:
                return 220;
                break;
            case 1024:
                return 240;
                break;
            case 2048:
                return 260;
                break;
            case 4096:
                return 280;
                break;
        }
        return 0;
    }

    public int GetScore()
    {
        return _score;
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
