using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public static event EventHandler OnPauseAction;
    [SerializeField] private Button pauseButton;

    new public static void ResetStaticData()
    {
        OnPauseAction = null;
    }
    
    private void Awake()
    {
        pauseButton.onClick.AddListener(PauseButton);
        
        Show();
    }

    private void PauseButton()
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
