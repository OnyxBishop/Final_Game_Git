using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _checkPointAudio;

    private AudioSource _audioSource;
    private CheckPoint _checkPoint;

    public void Initialise(CheckPoint checkPoint)
    {
        _audioSource = GetComponent<AudioSource>();
        Play();

        _checkPoint = checkPoint;
        _checkPoint.Reached += OnCheckPointReached;
    }

    private void OnDisable()
    {
        _checkPoint.Reached -= OnCheckPointReached;
    }

    public void Play()
    {
        _audioSource.clip = _backgroundMusic;
        _audioSource.Play();
        _audioSource.loop = true;
    }

    private void OnCheckPointReached()
    {
        _audioSource.PlayOneShot(_checkPointAudio);
    }
}
