using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseBase : MonoBehaviour
{
    protected Player _player;
    protected PotionSO _potion;
    protected int _healingAmount;
    protected int _quantity;

    private float _coolTime;
    private bool _isCoolTime = false;

    public event Action<int> OnPotionUsed;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    public virtual void Potion(PotionSO data, int quantity)
    {
        _potion = data;
        _healingAmount = data.HealingAmount;
        _quantity = quantity;
    }

    public virtual void UsePotion()
    {
        if (_isCoolTime)
            return;

        if(_potion == null || _quantity <= 0)
        {
            Debug.Log("포션을 장착해주세요");
        }
        else
        {
            _coolTime = 3f;

            Healing();
            _quantity--;

            OnPotionUsed?.Invoke(_quantity);

            StartCoroutine(CoolTimeController());
        }
    }

    protected virtual void Healing() {}

    IEnumerator CoolTimeController()
    {
        _isCoolTime = true;

        while(_coolTime > 0f)
        {
            _coolTime -= Time.deltaTime;

            yield return null;
        }

        _isCoolTime = false;
    }

}
