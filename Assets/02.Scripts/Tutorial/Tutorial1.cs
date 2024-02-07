using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Tutorial1 : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Ease _easeType;

    public Image TutorialImage;
    public TextMeshProUGUI TutorialText;

    private Coroutine _coroutine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
