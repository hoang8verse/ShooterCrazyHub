using System;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _Player;
    [SerializeField]
    private Slider _silderHP;
    [SerializeField]
    private Slider _silderRangeWeapon;
    [SerializeField]
    private Slider _silderDamageWeapon;
    [SerializeField]
    private Slider _silderReloatingWeapon;

    DamageTarget _playerDamageTarget;
    RifleWeapon _playerRifleWeapon;
    TargetFinder _playerTargetFinder;


    const int MAX_HP = 60;
    int _minHP;

    const int MAX_BULLET_RANGE = 50;
    float _minBulletRange;

    const int MAX_DAMAGE_PER_BULLET = 100;
    int _minDamagePerBullet;

    const float UNIT_RELOADING_TIME = 0.05f;
    float _minReloadingTime;
    // Use this for initialization
    void Start()
    {
        _playerDamageTarget = _Player.GetComponent<DamageTarget>();
        _minHP = _playerDamageTarget.MaxHP;

        _playerTargetFinder = _Player.GetComponent<TargetFinder>();
        _minBulletRange = _playerTargetFinder.GetRadius();

        _playerRifleWeapon = _Player.GetComponent<RifleWeapon>();
        _minDamagePerBullet = _playerRifleWeapon.Get().GetDamage();
        _minReloadingTime = _playerRifleWeapon.Get().GetReloadingTime();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePlayerHP()
    {
        
        int hp = _minHP + Mathf.RoundToInt(MAX_HP * _silderHP.value);
        _playerDamageTarget.SetHP(hp);
    }

    public void ChangeBulletRange()
    {
        float range = _minBulletRange + MAX_BULLET_RANGE * _silderRangeWeapon.value;
        _playerTargetFinder.SetRadius(range);
    }
    public void ChangeDamagePerBullet()
    {
        
        int damage = _minDamagePerBullet + Mathf.RoundToInt(MAX_DAMAGE_PER_BULLET * _silderDamageWeapon.value);
        _playerRifleWeapon.Get().SetDamage(damage);
    }
    public void ChangeReloadingTime()
    {
        float time = _minReloadingTime - UNIT_RELOADING_TIME * _silderReloatingWeapon.value * 10;
        _playerRifleWeapon.Get().SetReloadingTime(time);
    }
}
