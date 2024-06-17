using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    // �⺻ ���Ȱ� ���� ���ȵ��� �ɷ�ġ�� �����ؼ� ������ ����ϴ� ������Ʈ
    [SerializeField] private CharacterStat baseStats;

    public CharacterStat CurrentStat { get; private set; }

    //���������ʹ� ���⿡ ��´�
    public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStat();
        UpdateSize();
    }

    private void UpdateCharacterStat()
    {
        // statModifier�� �ݿ��ϱ� ���� baseStat�� ���� �޾ƿ�
        StatSO statSO = null;

        // baseStats �� Ȱ���ؼ� statSO, CurrentStat �� �ʱ�ȭ �Ѵ�
        if (baseStats.statSO != null)
        {
            // Instantiate �� ����ϸ� ������ �ƴ� ���纻�� �����ȴ�
            // �׷��� ���� ���Ҷ� ������ ������ ���� �ʴ´� - ���� �ٸ� �ΰ��� ����� 
            statSO = Instantiate(baseStats.statSO);
        }
        
        //�⺻ �ɷ�ġ ����
        CurrentStat = new CharacterStat { statSO = statSO };
        
    }

    private void UpdateSize()
    {
        float size = CurrentStat.statSO.size;
        transform.localScale = new Vector3(size, size, size);
    }
}
