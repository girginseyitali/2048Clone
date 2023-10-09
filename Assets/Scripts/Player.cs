using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pushForce;
    [SerializeField] private float cubeMaxPosX;
    [Space] 
    [SerializeField] private TouchSlider _touchSlider;

    private Cube mainCube;
    
    private bool isPointerDown;
    private Vector3 cubePos;

    private void Start()
    {
        SpawnCube();
        
        //Add touch slider events:
        _touchSlider.OnPointerDownEvent += TouchSlider_OnPointerDown;
        _touchSlider.OnPointerUpEvent += TouchSlider_OnPointerUp;
        _touchSlider.OnPointerDragEvent += TouchSlider_OnPointerDrag;
    }

    private void Update()
    {
        if (isPointerDown)
        {
            mainCube.transform.position = Vector3.Lerp(mainCube.transform.position, cubePos, moveSpeed * Time.deltaTime);
        }
    }

    private void TouchSlider_OnPointerDrag(float xMovement)
    {
        if (isPointerDown)
        {
            cubePos = mainCube.transform.position;
            cubePos.x = xMovement * cubeMaxPosX;
        }
    }

    private void TouchSlider_OnPointerUp()
    {
        if (isPointerDown)
        {
            isPointerDown = false;
            //Push the cube:
            mainCube.cubeRigidbody.AddForce(Vector3.forward* pushForce, ForceMode.Impulse);
            
            // todo: Spawn a new cube after 0.3 seconds:
            Invoke(nameof(SpawnNewCube), 0.3f);    
            
        }
    }

    private void SpawnNewCube()
    {
        mainCube.isMainCube = false;
        SpawnCube();
    }

    private void TouchSlider_OnPointerDown()
    {
        isPointerDown = true;
    }

    private void SpawnCube()
    {
        mainCube = CubeSpawner.Instance.SpawnRandom();
        mainCube.isMainCube = true;
        cubePos = mainCube.transform.position;
    }
    
    private void OnDestroy()
    {
        _touchSlider.OnPointerDownEvent -= TouchSlider_OnPointerDown;
        _touchSlider.OnPointerUpEvent -= TouchSlider_OnPointerUp;
        _touchSlider.OnPointerDragEvent -= TouchSlider_OnPointerDrag;
    }
}
