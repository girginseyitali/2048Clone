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
