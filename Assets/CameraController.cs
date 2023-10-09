using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }
    [SerializeField] private CinemachineVirtualCamera mainCam;

    private void Awake()
    {
        Instance = this;
        mainCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ApplyCameraShake(float shakeAmount, float duration)
    {
        mainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeAmount;
        Invoke(nameof(ResetCameraShake), duration);
    }

    public void ResetCameraShake()
    {
        mainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.0f;
    }
    
    
}
