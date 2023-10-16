using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }
    public event EventHandler OnGameRestart;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        Instance = this;
        restartButton.onClick.AddListener(RestartButton);
    }

    private void Start()
    {
        RedZone.Instance.OnGameOver += RedZone_OnGameOver;
        Hide();
    }

    private void RedZone_OnGameOver(object sender, EventArgs e)
    {
        Show();
        UpdateScoreText();
        UpdateHighScoreText();
    }

    private void RestartButton()
    {
        //Hide();
        //OnGameRestart?.Invoke(this, EventArgs.Empty);
        SceneManager.LoadScene(0);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {ScoreManager.Instance.GetScore()}";
    }

    private void UpdateHighScoreText()
    {
        ScoreManager.Instance.SetHighScore(ScoreManager.Instance.GetScore());
        highScoreText.text = $"HighScore: {ScoreManager.Instance.GetHighScore()}";
    }
}
