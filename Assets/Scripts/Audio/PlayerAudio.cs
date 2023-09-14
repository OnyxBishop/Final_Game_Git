using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips;
    [SerializeField] private Hero _hero;
    [SerializeField] private PlayerMovement _movement;

    private void OnEnable()
    {
        _hero.Died += OnHit;
        _movement.Jumped += OnJump;
    }

    private void OnDisable()
    {
        _hero.Died -= OnHit;
        _movement.Jumped -= OnJump;
    }

    public void PlayOneShot(Audio audioName)
    {
        foreach (AudioClip clip in _audioClips)
            if (clip.name == audioName.ToString())
                _audioSource.PlayOneShot(clip);
    }

    public void OnMove()
    {
        PlayOneShot(Audio.Footstep);
    }

    private void OnJump()
    {
        PlayOneShot(Audio.Jump);
    }

    private void OnHit()
    {
        PlayOneShot(Audio.Hit);
    }
}