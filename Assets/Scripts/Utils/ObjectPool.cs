using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // ������Ʈ Ǯ �����͸� ������ ������ ���� ����
    [System.Serializable]
    public class Pool
    {
        // ������Ʈ �±�
        public string tag;
        // ������ ������
        public GameObject prefab;
        // ��� �����Ұ���
        public int size;
    }

    public List<Pool> Pools;
    // ť�� ������ �ؼ� ���� ���� ������ �긦 �ִ� ���
    // Dictionary �� ����� ť�� ������ ���� �±׿� �Բ� ����
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        // �ν�����â�� Pools�� �������� ������ƮǮ�� ���� ��. 
        // ������ƮǮ�� ������ �����鸶�� ����
        // pool size�� �Ѿ�� ���� ���� Ȱ��ȭ�� ������Ʈ�� ���� ���Ҵ�.
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in Pools)
        {
            // ť�� FIFO(First-in First-out) �����μ�, ���� ���� ��ó�� ���� ���� �� ��(enqueue) ��ü�� ���� ���� ���� ����(dequeue) �� �ִ� ����
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // Awake�ϴ� ���� ������ƮǮ�� �� Instantitate �Ͼ�� ������ �͹��Ͼ��� ������ ����                
                // pool ��������� ������Ʈ Ǯ�� �ڽ����� ������
                GameObject obj = Instantiate(pool.prefab, transform);

                obj.SetActive(false);                
                objectPool.Enqueue(obj);
            }
            // ������ ���� Dictionary�� ���
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        // ���ʿ� Pool�� �������� �ʴ� ���
        if (!PoolDictionary.ContainsKey(tag)) return null;
        
        // ���� ������ ��ü�� ��Ȱ���ϴ� ���
        // ���� �ش� ��ü�� ����ִٸ� ������ �߻� 
        // ���� �ϱ����� ȭ�鿡 �ִ� ���� ������ ���ش�
        // �ٸ�������δ� ����Ʈ�� ����ؼ�
        // �ش� ������Ʈ�� ��������� Ȯ���Ѵ�

        //Dequeue �� ���ؼ� ť��Ͽ����� �������� 
        //������Ʈ�� �ı��Ѵ°��� �ƴϴ�
        //�ٽ� ť�� �־��ָ� ��Ȱ�� �����ϴ�        
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        obj.SetActive(true);
        return obj;
    }
}
