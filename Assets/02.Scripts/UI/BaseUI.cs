using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    public void CloseUI()
    {
        GameManager.instance.UIManager.CloseLastCanvas();
    }
    // 공통 기능 추가 생각

    public void ShowOneSecUI(GameObject UI, float sec) 
    {
        UI.SetActive(true);
        StartCoroutine(WaitOneSec(UI, sec));
    }

    IEnumerator WaitOneSec (GameObject UI,float sec)
    {
        yield return new WaitForSeconds(sec);
        UI.SetActive(false);
    }
    private void OnEnable()
    {
        
    }
}
