using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnPaused;
    public static GameManager Instance { get; private set; }

    private enum GameStates
    {
        InGame,
        GameOver
    }

    private GameStates _states;
    private bool _isPaused = false;
    
    private void Awake()
    {
        Instance = this;
        _states = GameStates.InGame;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InGameUI.Instance.OnPauseAction += InGameUI_OnPauseAction;
    }

    private void InGameUI_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    private void Update()
    {
        switch (_states)
        {
            case GameStates.InGame:
                break;
            case GameStates.GameOver:
                break;
        }
    }

    public void TogglePauseGame()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnPaused?.Invoke(this, EventArgs.Empty);
        }
    }

    
    public bool IsGamePlaying()
    {
        return _states == GameStates.InGame;
    }
}
