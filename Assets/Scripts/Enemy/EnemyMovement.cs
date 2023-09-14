using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AnimationSetter _animationSetter;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private const float _MaxSpeed = 4f;
    private const float _MinSpeed = 1f;

    private Vector2 _velocity;

    bool _isFlipped;

    public Vector2 Rigidbody2DPosition => _rigidbody.position;

    public void MoveTo(Transform point, float moveSpeed)
    {
        Vector2 targetVelocity = ((Vector2)point.position - _rigidbody.position).normalized;
        moveSpeed = Mathf.Clamp(moveSpeed, _MinSpeed, _MaxSpeed);
        _velocity.x = targetVelocity.x * moveSpeed;

        Vector2 deltaPosition = _velocity * Time.deltaTime;       
        float distance = deltaPosition.magnitude;
        _rigidbody.position += deltaPosition.normalized * distance;

        Flip(targetVelocity);

        _animationSetter.SetHorizontalMove(_velocity.x);
    }

    private void Flip(Vector2 targetVelocity)
    {
        if (targetVelocity.x < 0)
            _isFlipped = false;
        else if (targetVelocity.x > 0)
            _isFlipped = true;

        _spriteRenderer.flipX = _isFlipped;
    }
}
