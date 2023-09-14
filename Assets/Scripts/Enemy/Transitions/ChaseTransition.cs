using UnityEngine;

public class ChaseTransition : Transit
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out _))
            IsNeedTransit = true;
    }
}
