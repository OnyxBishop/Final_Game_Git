using UnityEngine;

public class PatrolTransition : Transit
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out _))
            IsNeedTransit = true;
    }
}
