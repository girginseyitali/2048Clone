using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    public event EventHandler OnGameOver;
    public static RedZone Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();
        if (cube != null)
        {
            if (!cube.isMainCube && cube.cubeRigidbody.velocity.magnitude < .1f)
            {
                //todo: Add GameOver Screen
                Debug.Log("GAME OVER!");
                OnGameOver?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
