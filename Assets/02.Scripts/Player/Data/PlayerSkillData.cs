using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class SkillInfoData
{
    [field: SerializeField] private string SkillName;
    [field: SerializeField] private int SkillCost;
    [field: SerializeField] private float SkillCoolTime;
    [field: SerializeField] private int SkillDamage;
    [field: SerializeField] private float SkillRange;
    [field: SerializeField] private float SkillDistance;
    [field: SerializeField] private string SkillPrefabsName;

    public int GetSkillCost() { return SkillCost; }
    public int GetSkillDamage() { return SkillDamage; }
    public float GetSkillCoolTime() { return SkillCoolTime; }
    public float GetSkillRange() { return SkillRange; }
    public float GetSkillDistance() { return SkillDistance; }
    public string GetSkillPrefabsName() { return SkillPrefabsName; }

}

[Serializable]
public class PlayerSkillData
{
    [field: SerializeField] public List<SkillInfoData> SkillInfoDatas;

    public SkillInfoData GetSkillData(int skillIndex) { return SkillInfoDatas[skillIndex]; }

}


