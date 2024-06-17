using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPlaying = true;


    private void Awake()
    {
        // 인스턴스가 이미 생성 되었다면 게임 매니저 오브젝트 파괴 
        if (Instance != null) Destroy(gameObject);

        Instance = this;
    }

    public void GameOver()
    {
        // 게임오버 UI 오브젝트 활성화 
        // 게임 종료
        isPlaying = false;
        Debug.Log("게임오버");
    }

    public bool ReturnIsPlaying()
    {
        return isPlaying;
    }
}
