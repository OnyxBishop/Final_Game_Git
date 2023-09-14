using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private CameraMover _camera;
    [SerializeField] private Score _score;

    [Header("StartLevel")]
    [SerializeField] private Spawn _spawn;
    [SerializeField] private GameData _gameData;
    [SerializeField] private LevelLoader _levelLoader;

    private Hero _hero;

    private void Awake()
    {
        LoadHero();
        LoadUI();
        LoadLevel();
    }

    private void LoadHero()
    {
        _spawn.Initialise();
        _hero = _spawn.HeroInstance;
        _camera.Initialise(_hero);
    }

    private void LoadUI()
    {
        _score.Initialise(_hero, _gameData);
    }

    private void LoadLevel()
    {
        _levelLoader.Initialise(_hero, _gameData);       
    }
}
