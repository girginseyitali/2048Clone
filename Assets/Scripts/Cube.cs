using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private static int staticID = 0;
    [SerializeField] private TMP_Text[] numbersText;

    [HideInInspector] public int cubeID;
    [HideInInspector] public Color cubeColor;
    [HideInInspector] public int cubeNumber;
    [HideInInspector] public Rigidbody cubeRigidbody;
    [HideInInspector] public bool isMainCube;

    private MeshRenderer cubeMeshRenderer;

    private void Awake()
    {
        cubeID = staticID++;
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    public void SetColor(Color color)
    {
        cubeColor = color;
        cubeMeshRenderer.material.color = color;
    }

    public void SetNumber(int number)
    {
        cubeNumber = number;
        for (int i = 0; i < 6; i++)
        {
            numbersText[i].text = number.ToString();
        }
    }
}
