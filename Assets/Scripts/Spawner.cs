using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubeTamplate;
    [SerializeField] private CubeCollisionChecker _cubeCollisionChecker;

    private void OnEnable() 
    {
        _cubeCollisionChecker.CubeCollison += OnCubeCollision;
    }

    private void OnDisable() 
    {
        _cubeCollisionChecker.CubeCollison -= OnCubeCollision;
    }

    private void OnCubeCollision(Vector3 lastCubePosition)
    {
        Cube newCube = Instantiate(_cubeTamplate, lastCubePosition, Quaternion.identity);
        newCube.MainCube = true;
    }
}
