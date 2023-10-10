using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button menuCloseButton;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI sfxText;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        menuCloseButton.onClick.AddListener(MenuCloseButton);
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        sfxSlider.onValueChanged.AddListener(OnSfxSliderValueChanged);
    }

    private void Start()
    {
        InGameUI.Instance.OnOptionsAction += InGameUI_OnOptionsAction;
        UpdateVisual();
        Hide();
    }

    private void InGameUI_OnOptionsAction(object sender, EventArgs e)
    {
        Show();
    }

    private void OnMusicSliderValueChanged(float value)
    {
        UpdateVisual();
        SoundManager.Instance.SetMusicVolume(value);
    }
    
    private void OnSfxSliderValueChanged(float value)
    {
        UpdateVisual();
        SoundManager.Instance.SetSfxVolume(value);
    }

    private void MenuCloseButton()
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateVisual()
    {
        musicSlider.value = SoundManager.Instance.GetMusicVolume();
        sfxSlider.value = SoundManager.Instance.GetSfxVolume();
        
        musicText.text = $"Music: {(musicSlider.value * 100).ToString("00")}";
        sfxText.text = $"SFX: {(sfxSlider.value * 100).ToString("00")}";
    }
}
