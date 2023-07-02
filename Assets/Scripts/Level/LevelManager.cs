using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class LevelManager : MonoBehaviour, IWorldMovementHandler
{
    public ReactiveProperty<int> CurrentLevel => _currentLevelNumber;

    public float LevelSwitchDelay = 3.5f;
    private float LevelStartDelay = 1f;

    [SerializeField]
    private World _world;

    [SerializeField]
    private SpawnArea _spawnArea;

    [SerializeField]
    private EnemyWavesFactoryProvider _wavesFactoryProvider;

    [SerializeField]
    private float _distanceBetweenStages;

    private IntReactiveProperty _currentLevelNumber = new IntReactiveProperty(1);

    private IEnemyWavesFactory _wavesFactory => _wavesFactoryProvider.Get();

    private void Awake()
    {
        Setup();
    }

    public void OnWorldStartMovement()
    {
    }

    public void OnWorldEndMovement()
    {
        StartCoroutine(IncrementLevelNumber());
    }

    private void Setup()
    {
        _spawnArea.AreaCleared
            .Delay(TimeSpan.FromSeconds(LevelSwitchDelay))
            .Subscribe(_ => GoToNextLevel())
            .AddTo(this);

        _currentLevelNumber
            .Subscribe(stage => SetupLevel(stage))
            .AddTo(this);
    }

    private void GoToNextLevel()
    {
        _world.MoveBackFor(_distanceBetweenStages);
    }

    private void SetupLevel(int levelNumber)
    {
        Debug.Log($"Spawn waves. Level: {levelNumber}");
        _spawnArea.SpawnWaves(_wavesFactory.CreateWaves(levelNumber));
    }

    private IEnumerator IncrementLevelNumber()
    {
        yield return new WaitForSeconds(LevelStartDelay);

        _currentLevelNumber.Value = _currentLevelNumber.Value + 1;
    }
    public SpawnArea GetSpawnArea()
    {
        return _spawnArea;
    }
    public void SetRangeSpawnArea(float range)
    {
        _spawnArea.gameObject.transform.position = new Vector3(0, 0, range);
    }
}
