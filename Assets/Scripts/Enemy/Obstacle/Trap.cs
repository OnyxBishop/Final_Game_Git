using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Hero>(out Hero hero))
            hero.Die();
    }
}
