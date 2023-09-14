using UnityEngine;
using UnityEngine.Events;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Hero _heroPrefab;

    public UnityAction<Hero> Spawned;

    private Hero _heroInstance;

    public Hero HeroInstance => _heroInstance;

    public void Initialise()
    {
        _heroInstance = Instantiate(_heroPrefab,
            new Vector2(transform.position.x,transform.position.y), Quaternion.identity);

        _heroInstance.Initialise();
        Spawned?.Invoke(_heroInstance);
    }
}
