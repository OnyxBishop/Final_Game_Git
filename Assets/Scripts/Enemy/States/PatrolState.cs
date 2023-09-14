using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private List<Transform> _path;

    private float _pointOffset = 0.5f;
    private int _currentPointIndex;

    private float _moveSpeed = 2f;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Mathf.Abs(Movement.Rigidbody2DPosition.x - _path[_currentPointIndex].position.x) <= _pointOffset)
            _currentPointIndex = ++_currentPointIndex % _path.Count;
        else
            Movement.MoveTo(_path[_currentPointIndex], _moveSpeed);
    }
}
