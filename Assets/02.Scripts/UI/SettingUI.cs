using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingUI : BaseUI
{
    [SerializeField] private Button _guideButton; //
    [SerializeField] private Button _checksaveButton;
    [SerializeField] private Button _checkExitButton;
    [SerializeField] private GameObject _savePanel;
    [SerializeField] private GameObject _exitCheck;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _keyControlButton;
    [SerializeField] private Button _homeButton;
    private void OnEnable()
    {
        _savePanel.SetActive(false);
        _exitCheck.SetActive(false);
        _homeButton.gameObject.SetActive(false);
        _checksaveButton.gameObject.SetActive(true);
        _checkExitButton.interactable = true;
        _checksaveButton.interactable = true;
        _keyControlButton.interactable = true;
        if (GameManager.Instance.GlobalTimeManager.Day == 0 || SceneManager.GetActiveScene().name == SceneName.TycoonScene)
        {
            _checksaveButton.interactable = false;
            if (SceneManager.GetActiveScene().name ==SceneName.TitleScene)
            {
                _checkExitButton.interactable = false;
                _checksaveButton.interactable = false;
                _keyControlButton.interactable = false;
            }
        }

        if (SceneManager.GetActiveScene().name == SceneName.DungeonScene)
        {
            _checksaveButton.interactable = false;
            _checksaveButton.gameObject.SetActive(false);
            _homeButton.gameObject.SetActive(true);
        }
    }
    private void Start()
    {
        _guideButton.onClick.AddListener(OpenGuideBook);
        _checksaveButton.onClick.AddListener(SaveGame);
        _checkExitButton.onClick.AddListener(ShowExitGame);
        _exitButton.onClick.AddListener(ExitGame);
        _keyControlButton.onClick.AddListener(ShowControlKey);
        _homeButton.onClick.AddListener(GoSleep);
    }

    private void OpenGuideBook()
    {
        GameManager.Instance.UIManager.ShowCanvas(UIName.ChoiceTutorialUI);
    }

    private void GoSleep()
    {
        base.CloseUI();
        GameManager.Instance.UIManager.PopupDic[UIName.RestartUI].SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    private void SaveGame() 
    {
        StartCoroutine(ShowPopupForSeconds(_savePanel, 2f));
    }
    private void ShowExitGame() 
    {
        _exitCheck.SetActive(true);
    }
    private void ShowControlKey()
    {
        GameManager.Instance.UIManager.ShowCanvas(UIName.ControlKeyUI);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
