using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPlaying = true;


    private void Awake()
    {
        // �ν��Ͻ��� �̹� ���� �Ǿ��ٸ� ���� �Ŵ��� ������Ʈ �ı� 
        if (Instance != null) Destroy(gameObject);

        Instance = this;
    }

    public void GameOver()
    {
        // ���ӿ��� UI ������Ʈ Ȱ��ȭ 
        // ���� ����
        isPlaying = false;
        Debug.Log("���ӿ���");
    }

    public bool ReturnIsPlaying()
    {
        return isPlaying;
    }
}
