using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest Data")]
public class QuestSO : ScriptableObject
{
    [field: SerializeField] public DailyQuestData EnemyQuestData { get; private set; }
    [field: SerializeField] public DailyQuestData NatureQuestData { get; private set; }

}