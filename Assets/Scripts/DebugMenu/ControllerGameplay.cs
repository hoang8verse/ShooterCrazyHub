using System;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGameplay : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _gameplayManager;
    [SerializeField]
    private Slider _silderSpawnRange;
    [SerializeField]
    private Slider _silderTimerSpawn;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textTimerSpawn;

    LevelManager _levelManager;

    float _minRangeSpwan;
    float _minTimerSpwan;
    // Use this for initialization
    void Start()
    {
        _levelManager = _gameplayManager.GetComponent<LevelManager>();
        _minRangeSpwan = _levelManager.GetSpawnArea().gameObject.transform.position.z;
        _minTimerSpwan = _levelManager.LevelSwitchDelay;


    }
    private void Update()
    {
        _textTimerSpawn.text = _levelManager.LevelSwitchDelay .ToString("0.0") + "s";
    }

    public void ChangeRangeSpawn()
    {
        float range = _minRangeSpwan + _silderSpawnRange.value * 10;
        _levelManager.SetRangeSpawnArea(range);
    }
    public void ChangeTimerSpawn()
    {
        float timeDeplay = _minTimerSpwan - _silderTimerSpawn.value * 2;
        _levelManager.LevelSwitchDelay = timeDeplay;
    }

}
