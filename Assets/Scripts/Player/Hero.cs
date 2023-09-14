using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{
    [SerializeField] private AnimationSetter _animationSetter;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameData _playerData;

    public event UnityAction Died;
    public event UnityAction<int> ScoreChanged;

    private PlayerInput _playerInput;

    private int _score;

    public int Score => _score;

    public void Initialise()
    {
        LoadData();
        _playerInput = new PlayerInput();
        _playerMovement.Initialise(_playerInput);
    }

    public void Die()
    {
        _animationSetter.SetHit();        
        StopMove();
        Died?.Invoke();
    }

    public void AddScorePoints(int points)
    {
        if (points > 0)
            _score += points;
       
        ScoreChanged?.Invoke(_score);
    }

    public void StopMove()
    {
        _playerMovement.Stop();
    }

    private void LoadData()
    {
       _score = _playerData.Score;
    }
}

public enum Audio
{
    Footstep,
    Jump,
    Hit
}
