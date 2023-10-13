using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;


public class SoundManager : MonoBehaviour
{
    private const string PLAYERPREFS_SFX_VOLUME = "SoundEffectsVolume";
    private const string PLAYERPREFS_MUSIC_VOLUME = "MusicVolume";
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioRefsSO audioRefsSO;

    [SerializeField] private float _sfxVolume;
    [SerializeField] private float _musicVolume;

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;
    [SerializeField] private AudioMixerGroup musicMixerGroup;

    private void Awake()
    {
        Instance = this;
        
        _sfxVolume = PlayerPrefs.GetFloat(PLAYERPREFS_SFX_VOLUME, 1f);
        _musicVolume = PlayerPrefs.GetFloat(PLAYERPREFS_MUSIC_VOLUME, 1f);
    }

    private void Start()
    {
        sfxMixerGroup.audioMixer.SetFloat("SFXMix", Mathf.Log10(_sfxVolume)*20);
        musicMixerGroup.audioMixer.SetFloat("MusicMix", Mathf.Log10(_musicVolume) * 20);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        //AudioSource.PlayClipAtPoint(audioClip, position, _sfxVolume * volumeMultiplier);
        sfxSource.clip = audioClip;
        sfxSource.Play();
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    public void PlayCollisionSound(Vector3 position)
    {
        PlaySound(audioRefsSO.collision, position, 2);
    }

    public void SetSfxVolume(float volume)
    {
        _sfxVolume = volume;
        sfxMixerGroup.audioMixer.SetFloat("SFXMix", Mathf.Log10(_sfxVolume)*20);
        PlayerPrefs.SetFloat(PLAYERPREFS_SFX_VOLUME, _sfxVolume);
        PlayerPrefs.Save();
    }
    
    public float GetSfxVolume()
    {
        return _sfxVolume;
    }

    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
        musicMixerGroup.audioMixer.SetFloat("MusicMix", Mathf.Log10(_musicVolume) * 20);
        PlayerPrefs.SetFloat(PLAYERPREFS_MUSIC_VOLUME, _musicVolume);
        PlayerPrefs.Save();
    }

    public float GetMusicVolume()
    {
        return _musicVolume;
    }
}
