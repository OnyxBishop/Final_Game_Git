using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class CheckPoint : MonoBehaviour
{
    public event UnityAction Reached;

    protected Animator _animator;
    protected const string Victory = nameof(Victory);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out _))
        {
            _animator.Play(Victory);
            Reached?.Invoke();
        }
    }
}
