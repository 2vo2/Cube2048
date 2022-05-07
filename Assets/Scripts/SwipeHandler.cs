using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class SwipeHandler : MonoBehaviour
{   
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _hitForce;
    [SerializeField] private float _maxXPosition;

    private Cube _cube;
    private Vector3 _positionCubeBeforeHit;

    public Vector3 PositionCubeBeforeHit => _positionCubeBeforeHit;

    private void Start() 
    {
        _cube = GetComponent<Cube>();    
    }

    private void Update() 
    {
        if(Input.GetMouseButton(0))
        {
            Swipe();
        }
        if(Input.GetMouseButtonUp(0))
        {
            HitCube();
        }
    }

    private void Swipe()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);

        if(_cube.MainCube)
        {
            if(position.x > 0)
            {
                if(position.x < _maxXPosition)
                    transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
            }
            else
            {
                if(position.x > -_maxXPosition)
                    transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
            }
        }
    }

    private void HitCube()
    {
        if(_cube.MainCube)
        {
            _positionCubeBeforeHit = transform.position;
            _rigidbody.AddForce(0, 0, _hitForce, ForceMode.Impulse);
            _cube.MainCube = false;
        }
    }
}
