using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CubeEqualsChecker : MonoBehaviour
{
    [SerializeField] private CubeCollisionChecker _cubeCollisonChecker;

    private Cube _cube;

    private void Start() 
    {
        _cube = GetComponent<Cube>();    
    }

    private void OnEnable() 
    {
        _cubeCollisonChecker.EqualsCube += OnEqualsCube;
    }

    private void OnDisable() 
    {
        _cubeCollisonChecker.EqualsCube -= OnEqualsCube;
    }

    private void OnEqualsCube(Cube cube)
    {
        if(cube.Value == _cube.Value)
        {
            int newValue = cube.Value + _cube.Value;

            cube.SetValue(newValue);
            cube.SetColor(newValue);

            Destroy(_cube.gameObject);
        }
    }
}
