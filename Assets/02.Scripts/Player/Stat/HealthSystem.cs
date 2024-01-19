using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private PlayerSO _playerData;
    private int _maxHealth;
    private int _playerDef;

    private int _health;

    public event Action OnDie;

    public bool IsDead => _health == 0;

    private void Start()
    {
        _playerData = GetComponent<Player>().Data;

        _maxHealth = _playerData.GetPlayerData().GetPlayerMaxHealth();
        _health = _maxHealth;

        _playerDef = _playerData.GetPlayerData().GetPlayerDef();

        Debug.Log(_maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (_health == 0) return;
        //TODO DEF
        _health = Mathf.Max((_health + _playerDef) - damage, 0);

        if (_health == 0)
            OnDie.Invoke();

        //Debug.Log(_health);
    }

}
