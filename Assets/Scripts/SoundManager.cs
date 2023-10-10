using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SoundManager : MonoBehaviour
{
    private const string PLAYERPREFS_SFX_VOLUME = "SoundEffectsVolume";
    private const string PLAYERPREFS_MUSIC_VOLUME = "MusicVolume";
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioRefsSO audioRefsSO;

    private float _sfxVolume = 1f;
    private float _musicVolume = 1f;

    private void Awake()
    {
        Instance = this;

        _sfxVolume = PlayerPrefs.GetFloat(PLAYERPREFS_SFX_VOLUME, 1f);
        _musicVolume = PlayerPrefs.GetFloat(PLAYERPREFS_MUSIC_VOLUME, 1f);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, _sfxVolume * volumeMultiplier);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    public void PlayCollisionSound(Vector3 position)
    {
        PlaySound(audioRefsSO.collision, position);
    }

    public void SetSfxVolume(float volume)
    {
        _sfxVolume = volume;
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
        PlayerPrefs.SetFloat(PLAYERPREFS_MUSIC_VOLUME, _musicVolume);
        PlayerPrefs.Save();
    }

    public float GetMusicVolume()
    {
        return _musicVolume;
    }
}
