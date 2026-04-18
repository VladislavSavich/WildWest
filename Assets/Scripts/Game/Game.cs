using UnityEngine;

public class Game : MonoBehaviour
{
    private Player _player;
    private WaveStarter _waveStarter;
    private UICaller _uiCaller;
    private TimeSwitcher _timeSwitcher;

    private void OnDisable()
    {
        _uiCaller.ButtonWasPressed -= StartGame;
        _player.GameOver -= OnGameOver;
        _waveStarter.AllEnemysDead -= CompleteGame;
    }

    public void Initialize(Player player, WaveStarter waveStarter, UICaller uiCaller, TimeSwitcher timeSwitcher)
    {
        _player = player;
        _waveStarter = waveStarter;
        _uiCaller = uiCaller;
        _timeSwitcher = timeSwitcher;

        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        if (_uiCaller != null)
            _uiCaller.ButtonWasPressed += StartGame;

        if (_player != null)
            _player.GameOver += OnGameOver;

        if (_waveStarter != null)
            _waveStarter.AllEnemysDead += CompleteGame;
    }

    public void PrepareGame()
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
