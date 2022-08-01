using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task Data", menuName = "TaskData")]
public class TaskData : ScriptableObject
{
    public int xpReward;
    public int levelReq;
    public enum ability
    {
        Strength,
        Endurance,
        NaturalIntelligence,
        MedicalIntelligence,
        Charisma,
        Investigation
    }
    public ability abilityReq;
}
