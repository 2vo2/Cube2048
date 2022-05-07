using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cube))]
public class CubeCollisionChecker : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeInput;

    private Cube _cube;

    public event UnityAction<Vector3> CubeCollison;
    public event UnityAction<Cube> EqualsCube;

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.TryGetComponent(out Wall wall))
        {
            CubeCollison?.Invoke(_swipeInput.PositionCubeBeforeHit);
            Destroy(this);
        }
        if(collision.gameObject.TryGetComponent(out Cube cube))
        {
            CubeCollison?.Invoke(_swipeInput.PositionCubeBeforeHit);
            EqualsCube?.Invoke(cube);
            Destroy(this); 
        }
    }
}
