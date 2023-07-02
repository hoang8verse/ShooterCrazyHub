using System;
using UnityEngine;
using UnityEngine.UI;

public class ControllerEnemy : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _enemyObject;
    [SerializeField]
    private Slider _silderEnemyGreen;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textEnemyGreenHP;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textEnemyGreenSpeed;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textEnemyGreenDamage;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textEnemyGreenLevel;

    [SerializeField]
    private Slider _silderEnemyRed;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textEnemyRedHP;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textEnemyRedSpeed;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textEnemyRedDamage;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textEnemyRedLevel;

    Enemy _enemyGreen;
    Enemy _enemyRed;

    const int HP_PER_LEVEL = 5;
    const int DAMAGE_PER_LEVEL = 10;
    const float SPEED_PER_LEVEL = 0.05f;

    int _minGreenHP;
    int _minGreenDamagePerBullet;
    float _minGreenSpeed;

    int _minRedHP;
    int _minRedDamagePerBullet;
    float _minRedSpeed;

    // Use this for initialization
    void Start()
    {
        _enemyGreen = _enemyObject.GetComponent<EnemyWavesFactoryProvider>().GetEnemyGreen();
        _enemyRed = _enemyObject.GetComponent<EnemyWavesFactoryProvider>().GetEnemyRed();
        InitEnemyGreen();
        InitEnemyRed();

        UpdateGreenLevel(0);
        UpdateRedLevel(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitEnemyGreen()
    {
        _minGreenHP = _enemyGreen.GetComponent<DamageTarget>().MaxHP;
        _textEnemyGreenHP.text = _minGreenHP.ToString();
        _minGreenDamagePerBullet = _enemyGreen.GetComponent<EnemyBehaviour>().GetDamageAttach();
        _textEnemyGreenDamage.text = _minGreenDamagePerBullet.ToString();
        _minGreenSpeed = _enemyGreen.GetComponent<EnemyBehaviour>().GetSpeed();
        _textEnemyGreenSpeed.text = "1x";
    }
    void UpdateGreenLevel(int level)
    {
        int currentHP = _minGreenHP + level * HP_PER_LEVEL;
        _enemyGreen.GetComponent<DamageTarget>().SetHP(currentHP);
        _textEnemyGreenHP.text = currentHP.ToString();

        int currentDamage = _minGreenDamagePerBullet + level * DAMAGE_PER_LEVEL;
        _enemyGreen.GetComponent<EnemyBehaviour>().SetDamageAttach(currentDamage);
        _textEnemyGreenDamage.text = currentDamage.ToString();

        float currentSpeed = _minGreenSpeed - level * SPEED_PER_LEVEL;
        _enemyGreen.GetComponent<EnemyBehaviour>().SetSpeed(currentSpeed);

        if(level < 1)
        {
            level = 1;
        }
        if(level > 10)
        {
            level = 10;
        }
        _textEnemyGreenSpeed.text = level + "x";

        _textEnemyGreenLevel.text = "Level" + level;
    }
    void InitEnemyRed()
    {
        _minRedHP = _enemyRed.GetComponent<DamageTarget>().MaxHP;
        _textEnemyRedHP.text = _minRedHP.ToString();
        _minRedDamagePerBullet = _enemyRed.GetComponent<EnemyBehaviour>().GetDamageAttach();
        _textEnemyRedDamage.text = _minRedDamagePerBullet.ToString();
        _minRedSpeed = _enemyRed.GetComponent<EnemyBehaviour>().GetSpeed();
        _textEnemyGreenSpeed.text = "1x";
    }
    void UpdateRedLevel(int level)
    {
        int currentHP = _minRedHP + level * HP_PER_LEVEL;
        _enemyRed.GetComponent<DamageTarget>().SetHP(currentHP);
        _textEnemyRedHP.text = currentHP.ToString();

        int currentDamage = _minRedDamagePerBullet + level * DAMAGE_PER_LEVEL;
        _enemyRed.GetComponent<EnemyBehaviour>().SetDamageAttach(currentDamage);
        _textEnemyRedDamage.text = currentDamage.ToString();

        float currentSpeed = _minRedSpeed - level * SPEED_PER_LEVEL;
        _enemyRed.GetComponent<EnemyBehaviour>().SetSpeed(currentSpeed);

        if (level < 1)
        {
            level = 1;
        }
        if (level > 10)
        {
            level = 10;
        }
        _textEnemyRedSpeed.text = level + "x";

        _textEnemyRedLevel.text = "Level" + level;
    }
    public void ChangeGreenLevel()
    {
        int currentLevel = Mathf.RoundToInt(10 * _silderEnemyGreen.value);
        Debug.Log("currentLevel ======  " + currentLevel);
        UpdateGreenLevel(currentLevel);
    }
    public void ChangeRedLevel()
    {
        int currentLevel = Mathf.RoundToInt(10 * _silderEnemyRed.value);
        Debug.Log("currentLevel ======  " + currentLevel);
        UpdateRedLevel(currentLevel);
    }

}
