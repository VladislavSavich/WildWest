using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveStarter _waveStarter;
    [SerializeField] private UICaller _uiCaller;
    [SerializeField] private TimeSwitcher _timeSwitcher;

    private void OnEnable()
    {
        _uiCaller.ButtonWasPressed += StartGame;
        _player.GameOver += OnGameOver;
        _waveStarter.AllEnemysDead += CompleteGame;
    }

    private void OnDisable()
    {
        _uiCaller.ButtonWasPressed -= StartGame;
        _player.GameOver -= OnGameOver;
        _waveStarter.AllEnemysDead -= CompleteGame;
    }

    private void Start()
    {
        _uiCaller.CallStartScreen();
    }

    private void OnGameOver()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallLoseScreen();
    }

    private void CompleteGame()
    {
        _timeSwitcher.StopTime();
        _uiCaller.CallVictoryScreen();
    }

    private void StartGame()
    {
        _uiCaller.CloseAllScreens();
        _timeSwitcher.StartTime();
        _player.Reset();
        _waveStarter.Reset();
    }
}
