using UnityEngine;

public class OnPlatformMove : MonoBehaviour
{
    [SerializeField] private MovingPlatform movingPlatform;

    private Rigidbody2D _heroRigidbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D heroRigidbody))
            _heroRigidbody = heroRigidbody;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D heroRigidbody))
        {
            _heroRigidbody.velocity = Vector2.zero;
            _heroRigidbody = null;
        }
    }

    private void FixedUpdate()
    {
        if (_heroRigidbody != null)
            _heroRigidbody.velocity = movingPlatform.Velocity;
    }
}
