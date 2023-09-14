using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components Reference")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AnimationSetter _animationSetter;
    [SerializeField] private LayerMask _layer;

    [Header("Move Params")]
    [SerializeField] private float _minGroundNormalY = 0.65f;
    [SerializeField] private float _gravityModifier = 1.0f;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _doubleJumpPower;
    [SerializeField] private float _speed = 3.2f;

    public event UnityAction Jumped;

    private const float ShellRadius = 0.01f;
    private float _jumpCount;

    private PlayerInput _input;
    private Vector2 _velocity;
    private Vector2 _targetVelocity;
    private Vector2 _groundNormal;

    private ContactFilter2D _contactFilter = new();
    private List<RaycastHit2D> _hitBufferList = new(16);

    private bool _isGrounded;
    private bool _isFlipped;

    public void Initialise(PlayerInput input)
    {
        _input = input;
        _input.Enable();

        _input.Player.Jump.performed += ctx => OnJump();

        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(_layer);
        _contactFilter.useLayerMask = true;
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        _targetVelocity = _input.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        ApplyHorizontalMovement();

        _isGrounded = false;

        MoveHorizontally();
        MoveVertically();

        IsFlying();
    }

    public void Stop()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void Movement(Vector2 move, bool isVerticalMovement)
    {
        float distance = move.magnitude;

        if (distance > 0)
        {
            int hitCount = _rigidbody.Cast(move, _contactFilter, _hitBufferList, distance + ShellRadius);

            for (int i = 0; i < hitCount; i++)
            {
                HandleCollision(_hitBufferList[i], isVerticalMovement, ref distance);
            }
        }

        _rigidbody.position += move.normalized * distance;
    }

    private void HandleCollision(RaycastHit2D hit, bool isVerticalMovement, ref float distance)
    {
        Vector2 currentNormal = hit.normal;

        if (currentNormal.y > _minGroundNormalY)
        {
            _isGrounded = true;

            if (isVerticalMovement == true)
            {
                _groundNormal = currentNormal;
                currentNormal.x = 0f;
            }
        }

        float projection = Vector2.Dot(_velocity, currentNormal);

        if (projection < 0)
        {
            _velocity -= projection * currentNormal;
        }

        distance = Mathf.Min(distance, hit.distance - ShellRadius);
    }

    private void ApplyHorizontalMovement()
    {
        _velocity += _gravityModifier * Time.deltaTime * Physics2D.gravity;
        _velocity.x = _targetVelocity.x * _speed;

        Flip();

        if (_isGrounded == true)
            _animationSetter.SetHorizontalMove(_velocity.x);
    }

    private void MoveHorizontally()
    {
        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);
    }

    private void MoveVertically()
    {
        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    private void OnJump()
    {
        int maxJumps = 2;

        if (_isGrounded == true)
        {
            _velocity.y = _jumpPower;
            _jumpCount = 1;
            _animationSetter.SetJump(true);
            Jumped?.Invoke();
        }
        else if (_jumpCount < maxJumps)
        {
            _velocity.y = _doubleJumpPower;
            _jumpCount++;
            _animationSetter.SetDoubleJump(true);
            Jumped?.Invoke();
        }
    }

    private void IsFlying()
    {
        if (_velocity.y < 0f)
        {
            _animationSetter.SetJump(false);
            _animationSetter.SetFall(true);
            _animationSetter.SetDoubleJump(false);
        }
        else
        {
            _animationSetter.SetFall(false);
        }
    }

    private void Flip()
    {
        if (_targetVelocity.x < 0)
            _isFlipped = true;
        else if (_targetVelocity.x > 0)
            _isFlipped = false;

        _spriteRenderer.flipX = _isFlipped;
    }
}