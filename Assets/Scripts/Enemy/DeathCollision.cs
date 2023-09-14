using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Hero>(out Hero hero))
            hero.Die();
    }
}
