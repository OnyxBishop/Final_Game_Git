using UnityEngine;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> _path = new(2);
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _speed = 2f;
    private float _pointOffset = 0.1f;
    private int _currentPointIndex;

    public Vector2 Velocity => _rigidbody2D.velocity;

    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x - _path[_currentPointIndex].position.x) <= _pointOffset)
            _currentPointIndex = ++_currentPointIndex % _path.Count;
        else
        {
            Vector2 direction = ((Vector2)_path[_currentPointIndex].position - _rigidbody2D.position).normalized;
            Vector2 velocity = direction * _speed;
            _rigidbody2D.velocity = velocity;
        }

        _spriteRenderer.flipX = _rigidbody2D.velocity.x < 0;
    }
}
