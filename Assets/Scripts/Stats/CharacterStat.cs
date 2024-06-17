using System;
using UnityEngine;

public enum StatsChangeType
{
    Add, // 0
    Multiple, // 1
    Override, // 2
}

[Serializable]
public class CharacterStat
{
    // 스텟의 버프가 있을 수도 있다 - 아이템 획득
    public StatsChangeType statsChangeType;    
    
    public StatSO statSO;
}
