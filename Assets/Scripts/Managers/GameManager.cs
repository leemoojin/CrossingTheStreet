using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private void Awake()
    {
        // �ν��Ͻ��� �̹� ���� �Ǿ��ٸ� ���� �Ŵ��� ������Ʈ �ı� 
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
