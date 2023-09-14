using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private CheckPoint _checkPoint;
    [SerializeField] private BackgroundAudio _backgroundAudio;

    private const string Menu = nameof(Menu);
    private int _currentLevelIndex;

    private Hero _player;
    private GameData _gameData;
    private WaitForSeconds _waitFor = new(1.5f);
    private Coroutine _wait;

    public void Initialise(Hero player, GameData data)
    {
        _player = player;
        _gameData = data;
        _backgroundAudio.Initialise(_checkPoint);
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        _player.Died += OnDied;
        _checkPoint.Reached += OnCheckpointReached;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _checkPoint.Reached -= OnCheckpointReached;
    }

    private void OnDied()
    {
        if (_wait != null)
            StopCoroutine(_wait);

        _wait = StartCoroutine(SetLevel(_currentLevelIndex));
    }

    private void OnCheckpointReached()
    {
        _gameData.SaveGameProgress(_player);
        _player.StopMove();

        if (_wait != null)
            StopCoroutine(_wait);

        _wait = StartCoroutine(SetLevel(_currentLevelIndex + 1));
    }

    private IEnumerator SetLevel(int levelIndex)
    {
        yield return _waitFor;

        if (levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            SceneManager.LoadScene(Menu);
        }
    }
}
