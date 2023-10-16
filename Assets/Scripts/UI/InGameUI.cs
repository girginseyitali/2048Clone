using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public static InGameUI Instance { get; private set; }
    
    public event EventHandler OnPauseAction;
    public event EventHandler OnOptionsAction;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI newHighScoreLabel;
    
    private void Awake()
    {
        Instance = this;
        pauseButton.onClick.AddListener(PauseButton);
        optionsButton.onClick.AddListener(OptionsButton);
        Show();
    }

    private void Start()
    {
        newHighScoreLabel.gameObject.SetActive(false);
        ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChanged;
    }

    private void ScoreManager_OnScoreChanged(object sender, EventArgs e)
    {
        UpdateScore();
        if (ScoreManager.Instance.GetScore() > ScoreManager.Instance.GetHighScore())
        {
            newHighScoreLabel.gameObject.SetActive(true);
        }
    }

    private void PauseButton()
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void OptionsButton()
    {
        OnOptionsAction?.Invoke(this, EventArgs.Empty);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score: {ScoreManager.Instance.GetScore()}";
    }
}
