using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeCollision : MonoBehaviour
{
    private Cube cube;
    
    
    private void Awake()
    {
        cube = GetComponent<Cube>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Cube otherCube = collision.gameObject.GetComponent<Cube>();

        //Contact with other cube
        if (otherCube != null && cube.cubeID > otherCube.cubeID)
        {
            //Check if cubes numbers are equal
            if (cube.cubeNumber == otherCube.cubeNumber)
            {
                Vector3 contactPoint = collision.contacts[0].point;
                
                //Check if cubes number less than max number is CubeSpawner:
                if (otherCube.cubeNumber < CubeSpawner.Instance.maxCubeNumber)
                {
                    //Spawn a new cube as a result
                    Cube newCube = CubeSpawner.Instance.Spawn(cube.cubeNumber * 2, contactPoint + Vector3.up * 1.6f);
                    //Apply some force to the new cube
                    float pushForce = 2.5f;
                    newCube.cubeRigidbody.AddForce(new Vector3(0,.3f, 1f) * pushForce, ForceMode.Impulse);

                    float randomValue = Random.Range(20, -20);
                    Vector3 randomDirection = Vector3.one * randomValue;
                    newCube.cubeRigidbody.AddTorque(randomDirection);
                }

                Collider[] surroundedCubes = Physics.OverlapSphere(contactPoint, 2f);
                float explosionForce = 400f;
                float explosionRadius = 1.5f;

                foreach (Collider coll in surroundedCubes)
                {
                    if (coll.attachedRigidbody != null)
                    {
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
                    }
                }
                
                //todo: Explosion FX
                CameraController.Instance.ApplyCameraShake(0.5f, 0.2f);
                
                //Destroy the two cubes:
                CubeSpawner.Instance.DestroyCube(cube);
                CubeSpawner.Instance.DestroyCube(otherCube);
            }
        }
    }
}
