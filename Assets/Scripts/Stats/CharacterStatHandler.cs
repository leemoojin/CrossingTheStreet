using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    // 기본 스탯과 버프 스탯들의 능력치를 종합해서 스탯을 계산하는 컴포넌트
    [SerializeField] private CharacterStat baseStats;

    public CharacterStat CurrentStat { get; private set; }

    //버프데이터는 여기에 담는다
    public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStat();
        UpdateSize();
    }

    private void UpdateCharacterStat()
    {
        // statModifier를 반영하기 위해 baseStat을 먼저 받아옴
        StatSO statSO = null;

        // baseStats 을 활용해서 statSO, CurrentStat 을 초기화 한다
        if (baseStats.statSO != null)
        {
            // Instantiate 를 사용하면 원본이 아닌 복사본이 생성된다
            // 그래야 값이 변할때 원본이 영향을 받지 않는다 - 전혀 다른 두개를 만들기 
            statSO = Instantiate(baseStats.statSO);
        }
        
        //기본 능력치 세팅
        CurrentStat = new CharacterStat { statSO = statSO };
        
    }

    private void UpdateSize()
    {
        float size = CurrentStat.statSO.size;
        transform.localScale = new Vector3(size, size, size);
    }
}
