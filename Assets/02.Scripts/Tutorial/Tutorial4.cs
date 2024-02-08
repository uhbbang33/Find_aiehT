using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial4 : MonoBehaviour
{
    public EnemyHealthSystem[] TutorialChick;

    [SerializeField] private float _duration;
    [SerializeField] private Ease _easeType;

    public Image TutorialImage;
    public TextMeshProUGUI TutorialText;

    private Coroutine _coroutine;

    private int EnemyCount;

    private void OnEnable()
    {
        EnemyCount = TutorialChick.Length;
        for (int i = 0; i < TutorialChick.Length; ++i)
        {
            TutorialChick[i].gameObject.SetActive(true);
            TutorialChick[i].OnDie += KillEnemy;
        }
    }

    private void KillEnemy()
    {
        --EnemyCount;
        if(EnemyCount == 0)
        {
            DoMove();
        }
    }

    private void DoMove()
    {
        if (_coroutine == null)
        {
            TutorialImage.DOFade(0f, _duration).SetEase(_easeType);
            TutorialText.DOFade(0f, _duration).SetEase(_easeType);

            _coroutine = StartCoroutine(EndTutorial());
        }
    }

    private IEnumerator EndTutorial()
    {
        yield return new WaitForSeconds(_duration);
        gameObject.SetActive(false);
        _coroutine = null;
    }
}
