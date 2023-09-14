using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text _score;

     Hero _heroScore;
     GameData _playerData;

    public void Initialise(Hero score, GameData data)
    {
        _heroScore = score;
        _playerData = data;

        _heroScore.ScoreChanged += OnItemCollected;
        _score.text = _playerData.Score.ToString();
    }

    private void OnDisable()
    {
        _heroScore.ScoreChanged -= OnItemCollected;
    }

    private void OnItemCollected(int value)
    {
        if (value > 0)
            _score.text = value.ToString();
    }
}
