using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SkillInstantiator : MonoBehaviour
{
    [field: SerializeField] private GameObject SkillPos;

    private GameObject _skillPrefabs;

    private List<GameObject> _skillPrefabList;

    [field: SerializeField] private float _instantiateTime = 0.5f;

    private PlayerSO _playerSO;
    private List<string> _skillNames;

    private void Start()
    {
        _playerSO = GetComponent<Player>().Data;
        _skillNames = new List<string>();
        _skillPrefabList = new List<GameObject>();

        List<SkillInfoData> _skillData = _playerSO.SkillData.SkillInfoDatas;

        foreach (SkillInfoData skillInfoDatas in _skillData)
        {
            _skillNames.Add(skillInfoDatas.SkillPrefabsName);
        }

        foreach (string skillName in _skillNames)
        {

            StringBuilder _skillResourcePath = new StringBuilder("Prefabs/Skills/");
            _skillResourcePath.Append(skillName);

            _skillPrefabs = GameManager.Instance.ResourceManager.Load<GameObject>(_skillResourcePath.ToString());

            _skillPrefabList.Add(_skillPrefabs);
        }

    }

    public void InstantiateTomato()
    {
        foreach (GameObject tomatoPrefab in _skillPrefabList.Where(Prefab => Prefab != null && Prefab.name == "Tomato"))
        {
            InstanatiateSkill(tomatoPrefab, SkillPos.transform.position);
        }

    }


    private void InstanatiateSkill(GameObject skillPrefabs, Vector3 position)
    {
        StartCoroutine(DelayInstantiate(skillPrefabs, position));
    }

    IEnumerator DelayInstantiate(GameObject skillPrefabs, Vector3 position)
    {
        yield return new WaitForSeconds(_instantiateTime); 
        Instantiate(skillPrefabs, position, Quaternion.identity);
    }
}
