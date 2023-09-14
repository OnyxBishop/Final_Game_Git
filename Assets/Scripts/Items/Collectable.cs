using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    
    private const string IsCollected = nameof(IsCollected);

    private int _scorePoints = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out Hero hero))
        {
            _animator.SetBool(IsCollected, true);

            _audioSource.Play();

            hero.AddScorePoints(_scorePoints);

            StartCoroutine(Disappear());  
        }
    }

    private IEnumerator Disappear()
    {
        WaitForSeconds waitForSeconds = new(1f);

        yield return waitForSeconds;

        StopCoroutine(Disappear());

        gameObject.SetActive(false);
    }
}
