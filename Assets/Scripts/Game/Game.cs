using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveController _controller;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _loseScreen;
    [SerializeField] private EndScreen _victoryScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _loseScreen.RestartButtonClicked += OnRestartButtonClick;
        _victoryScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
        _controller.AllEnemysDead += CompleteGame;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _loseScreen.RestartButtonClicked -= OnRestartButtonClick;
        _victoryScreen.RestartButtonClicked -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
        _controller.AllEnemysDead -= CompleteGame;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _loseScreen.Open();
    }

    private void CompleteGame()
    {
        Time.timeScale = 0;
        _victoryScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _loseScreen.Close();
        _victoryScreen.Close();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        _controller.Reset();
    }
}
