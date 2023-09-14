using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MovingTrap
{
    [SerializeField] private List<Transform> _path = new(2);

    private int _currentPointIndex;
    private float _speed = 2.5f;

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        if (Mathf.Abs(transform.position.y - _path[_currentPointIndex].position.y) <= PointOffset)
            _currentPointIndex = ++_currentPointIndex % _path.Count;
        else
            transform.position = Vector2.MoveTowards(transform.position, _path[_currentPointIndex].position, _speed * Time.deltaTime);
    }
}
