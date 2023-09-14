using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private Spawn _spawn;

    private Hero _target;

    public Hero Target => _target;
    public EnemyMovement Movement => _movement;

    private void OnEnable()
    {
        _target = _spawn.HeroInstance;
    }
}
