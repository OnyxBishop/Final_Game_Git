using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private float _delay = 0.8f;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartClicked);
        _exitButton.onClick.AddListener(OnExitClicked);        
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartClicked);
        _exitButton.onClick.RemoveListener(OnExitClicked);
    }

    private void OnStartClicked()
    {
        StartCoroutine(LoadingGame());       
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }

    private IEnumerator LoadingGame()
    {
        WaitForSeconds wait = new(_delay);

        yield return wait;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
