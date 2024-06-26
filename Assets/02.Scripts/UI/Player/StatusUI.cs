using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StatusUI : BaseUI
{
    private PlayerSO _playerData;
    [SerializeField] private EquipmentBase[] _equipment= new EquipmentBase[6];

    private float _sumEquipDef = 0;
    private float _sumequipHealth = 0;
    private float _weaponDamage = 0;

    private bool _isActiveUI;

    private Coroutine _coroutine;

    [SerializeField] private EquipmentDatas _equipmentUpgrade;
    [Header("기본스탯")]
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerLevel;
    [SerializeField] private TMP_Text _maxHealth;
    [SerializeField] private TMP_Text _maxStamina;
    [SerializeField] private TMP_Text _attack;
    [SerializeField] private TMP_Text _defence;

    [Header("장비 정보")]
    [SerializeField] private Image[] _equipmentSprite = new Image[6];
    [SerializeField] private TMP_Text[] _equipmentName= new TMP_Text[6];
    
    [SerializeField] private TMP_Text _equipmentHealth;
    [SerializeField] private TMP_Text _equipmentDef;
    [SerializeField] private TMP_Text _weaponDamageText;


    [Header("스킬정보")]
    [SerializeField] private TMP_Text _qSkillName;
    [SerializeField] private TMP_Text _qSkillDmg;
    [SerializeField] private TMP_Text _qSkillCool;
    [SerializeField] private TMP_Text _qSkillStamina;
    [SerializeField] private TMP_Text _eSkillName;
    [SerializeField] private TMP_Text _eSkillDmg;
    [SerializeField] private TMP_Text _eSkillCool;
    [SerializeField] private TMP_Text _eSkillStamina;

    private void Awake()
    {
        _isActiveUI = false;

        _equipmentUpgrade = GameManager.Instance.Player.GetComponent<EquipmentDatas>();
        _playerData = GameManager.Instance.Player.GetComponent<Player>().Data;
        
    }

    private void OnEnable()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ActiveUIC0());
        }

        float playerDamage = _playerData.PlayerData.PlayerAttack;
        float tomatoSkillDamage = _playerData.SkillData.SkillInfoDatas[0].SkillDamage;
        float spreadSkillDamage = _playerData.SkillData.SkillInfoDatas[1].SkillDamage;
        int playerLevel = _playerData.PlayerData.PlayerLevel;

        _sumEquipDef = 0;
        _sumequipHealth = 0;
        _weaponDamage = 0;


        _playerName.text = _playerData.PlayerData.PlayerName;
        _playerLevel.text = playerLevel.ToString();
        

        for (int i = 0; i < _equipment.Length; i++)
        {
            _equipmentName[i].text = _equipmentUpgrade.EquipData[i].Equipment.Name + "(+" + _equipmentUpgrade.EquipData[i].Level.ToString() + ")";
            _equipmentSprite[i].sprite = _equipmentUpgrade.EquipData[i].Equipment.EquipSprite;

            _sumequipHealth += _equipmentUpgrade.EquipData[i].Currenthealth;
            _sumEquipDef += _equipmentUpgrade.EquipData[i].CurrentDef;
            _weaponDamage += _equipmentUpgrade.EquipData[i].CurrentAttack;
        }

        float tomatoSkillTotalDamage = playerDamage + (tomatoSkillDamage + _weaponDamage) * playerLevel;
        float spreadSkillTotalDamage = playerDamage + (spreadSkillDamage + _weaponDamage) * playerLevel;

        _equipmentHealth.text = "("+_sumequipHealth.ToString()+")";
        _equipmentDef.text = "("+_sumEquipDef.ToString()+")";
        _weaponDamageText.text = "("+_weaponDamage.ToString()+")";

        _maxHealth.text = (_playerData.PlayerData.PlayerMaxHealth + _sumequipHealth).ToString();
        _maxStamina.text = _playerData.PlayerData.PlayerMaxStamina.ToString();
        _attack.text = (playerDamage + _weaponDamage).ToString();
        _defence.text = (_playerData.PlayerData.PlayerDef + _sumEquipDef).ToString();

        _qSkillName.text = _playerData.SkillData.SkillInfoDatas[0].SkillName+"(Q)";


        _qSkillDmg.text = tomatoSkillTotalDamage.ToString();
        _qSkillCool.text = _playerData.SkillData.SkillInfoDatas[0].SkillCoolTime.ToString();
        _qSkillStamina.text = _playerData.SkillData.SkillInfoDatas[0].SKillCost.ToString();

        _eSkillName.text = _playerData.SkillData.SkillInfoDatas[1].SkillName + "(E)";
        _eSkillDmg.text = spreadSkillTotalDamage.ToString();
        _eSkillCool.text = _playerData.SkillData.SkillInfoDatas[1].SkillCoolTime.ToString();
        _eSkillStamina.text = _playerData.SkillData.SkillInfoDatas[1].SKillCost.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && _isActiveUI)
        {
            GameManager.Instance.UIManager.CloseLastCanvas();
        }
    }

    private void OnDisable()
    {
        _isActiveUI = false;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator ActiveUIC0()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        _isActiveUI = true;
        _coroutine = null;
    }
}
