using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private void Awake()
    {
        // 인스턴스가 이미 생성 되었다면 게임 매니저 오브젝트 파괴 
        if (Instance != null) Destroy(gameObject);

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
