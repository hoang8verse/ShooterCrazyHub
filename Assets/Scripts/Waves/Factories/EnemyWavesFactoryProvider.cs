using UnityEngine;

public class EnemyWavesFactoryProvider : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemyBugGreenPrefab;

    [SerializeField]
    private Enemy _enemyBugRedPrefab;

    public IEnemyWavesFactory Get()
    {
        return new FirstStageWaveFactory(_enemyBugGreenPrefab, _enemyBugRedPrefab);
    }
    public Enemy GetEnemyGreen()
    {
        return _enemyBugGreenPrefab;
    }
    public Enemy GetEnemyRed()
    {
        return _enemyBugRedPrefab;
    }
}
