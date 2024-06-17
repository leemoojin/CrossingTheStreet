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
    // ������ ������ ���� ���� �ִ� - ������ ȹ��
    public StatsChangeType statsChangeType;    
    
    public StatSO statSO;
}
