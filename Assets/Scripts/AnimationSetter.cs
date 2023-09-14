using UnityEngine;

public class AnimationSetter : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string HorizontalMove = nameof(HorizontalMove);
    private const string Jumping = nameof(Jumping);
    private const string DoubleJump = nameof(DoubleJump);
    private const string HitTrigger = nameof(HitTrigger);
    private const string Falling = nameof(Falling);

    public void SetHorizontalMove(float velocity)
    {
        _animator.SetFloat(HorizontalMove, Mathf.Abs(velocity));
    }

    public void SetJump(bool isJump)
    {       
        _animator.SetBool(Jumping, isJump);
    }

    public void SetDoubleJump(bool isJumping)
    {
        _animator.SetBool(DoubleJump, isJumping);
    }

    public void SetFall(bool isFly)
    {
        _animator.SetBool(Falling, isFly);
    }

    public void SetHit()
    {
        _animator.SetTrigger(HitTrigger);
    }
}
