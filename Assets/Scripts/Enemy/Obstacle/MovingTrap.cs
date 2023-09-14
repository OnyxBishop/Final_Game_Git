using UnityEngine;

public abstract class MovingTrap : MonoBehaviour
{
    protected float PointOffset = 0.1f;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Hero>(out Hero hero))
            hero.Die();
    }

    protected abstract void Move();
}
