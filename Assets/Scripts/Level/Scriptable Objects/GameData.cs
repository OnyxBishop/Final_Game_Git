using UnityEngine;

[CreateAssetMenu(fileName = "Save" , menuName = "Game Stats", order = 51)]
public class GameData : ScriptableObject
{
    private int _score;

    public int Score
    {
        get { return _score; }
        private set {  }
    }

    private void Reset()
    {
        _score = 0;
    }

    public void SaveGameProgress(Hero hero)
    {
        _score += hero.Score;
    }
}
