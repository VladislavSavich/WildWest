using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class GameInitiator : MonoBehaviour
{
    [SerializeField] private Light _directionalLight;
    [SerializeField] private Volume _globalVolume;
    [SerializeField] private Game _game;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private UICaller _uiCaller;
    [SerializeField] private Player _player;
    [SerializeField] private TimeSwitcher _timeSwitcher;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private WaveStarter _waveStarter;
    [SerializeField] private GameObject _firstPoint;
    [SerializeField] private GameObject _secondPoint;
    [SerializeField] private GameObject _thirdPoint;


    private void Start()
    {
        BindObjects();

        _game.Initialize(_player, _waveStarter, _uiCaller, _timeSwitcher);
    }

    private void BindObjects() 
    {
        _directionalLight = Instantiate(_directionalLight);
        _globalVolume = Instantiate(_globalVolume);
        _game = Instantiate(_game);
        _eventSystem = Instantiate(_eventSystem);
        _uiCaller = Instantiate(_uiCaller);
        _player = Instantiate(_player);
        _timeSwitcher = Instantiate(_timeSwitcher);
        _enemySpawner = Instantiate(_enemySpawner);
        _waveStarter = Instantiate(_waveStarter);
        _firstPoint = Instantiate(_firstPoint);
        _secondPoint = Instantiate(_secondPoint);
        _thirdPoint = Instantiate(_thirdPoint);
    }
}
