using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnMap();
    }

    private void SpawnMap()
    {
        Debug.Log($"SpawnManger.cs - SpawnMap()");

        string roadTag = ObjectPool.Instance.Pools[2].tag;
        int roadCount = ObjectPool.Instance.Pools[2].size;

        // ������Ʈ Ǯ�� �̿��ؼ� road ����
        // Tag �� Ȯ���ϰ� ������ �ض�
        for (int i = 0; i < roadCount; i++)
        {
            GameObject obj = ObjectPool.Instance.SpawnFromPool(roadTag);
            // road ��ġ ����
            if (i != 0)
            {
                obj.transform.position = obj.transform.position + new Vector3(0,0,i*6);
            }
            obj.SetActive(true);
        }

        

    }
}
