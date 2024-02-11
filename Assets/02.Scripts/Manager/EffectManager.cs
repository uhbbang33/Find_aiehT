using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPos;

    private WaitForSeconds _healingEffectTime = new WaitForSeconds(2f);
    private WaitForSeconds _playerAttackEffectTime = new WaitForSeconds(0.3f);

    private GameObject _player;
    private GameObject _healingObject;
    private GameObject _staminaHealingObject;
    private GameObject _playerAttackObject;
    private GameObject _footStepObject;

    [Header("Effect Prefabs")]
    [SerializeField] private GameObject _levelUpEffect;
    [SerializeField] private GameObject _healingEffect;
    [SerializeField] private GameObject _staminaHealingEffect;
    [SerializeField] private GameObject _playerAttackEffect;
    [SerializeField] private GameObject _footStepEffect;

    private void Start()
    {
        _player = GameManager.Instance.Player;

        _healingObject = Instantiate(_healingEffect, _player.transform);
        _healingObject.SetActive(false);

        _staminaHealingObject = Instantiate(_staminaHealingEffect, _player.transform);
        _staminaHealingObject.SetActive(false);

        _playerAttackObject = Instantiate(_playerAttackEffect, _weaponPos.transform);
        _playerAttackObject.SetActive(false);

        _footStepObject = Instantiate(_footStepEffect, _player.transform);
        _footStepObject.SetActive(false);
    }

    public void PlayLevelUpEffect()
    {
        GameObject levelupEffectObject = Instantiate(_levelUpEffect, _player.transform);
        Destroy(levelupEffectObject, 5f);
    }
    
    public void PlayHealingEffect()
    {
        _healingObject.SetActive(true);
        StartCoroutine(TurnOffEffect(_healingObject, _healingEffectTime));
    }

    public void PlayStanimaEffect()
    {
        _staminaHealingObject.SetActive(true);
        StartCoroutine(TurnOffEffect(_staminaHealingObject, _healingEffectTime));
    }

    public void PlayAttackEffect()
    {
        _playerAttackObject.SetActive(true);
        StartCoroutine(TurnOffEffect(_playerAttackObject, _playerAttackEffectTime));
    }

    public void PlayFootStepEffect()
    {
        _footStepObject.SetActive(true);
    }

    public void StopFootStepEffect()
    {
        _footStepObject.SetActive(false);
    }

    #region Coroutine

    IEnumerator TurnOffEffect(GameObject effectObject, WaitForSeconds effectTime)
    {
        yield return effectTime;
        effectObject.SetActive(false);
    }

    #endregion
}
