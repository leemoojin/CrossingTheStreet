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

        // 오브젝트 풀을 이용해서 road 세팅
        // Tag 을 확인하고 생성을 해라
        for (int i = 0; i < roadCount; i++)
        {
            GameObject obj = ObjectPool.Instance.SpawnFromPool(roadTag);
            // road 위치 세팅
            if (i != 0)
            {
                obj.transform.position = obj.transform.position + new Vector3(0,0,i*6);
            }
            obj.SetActive(true);
        }

        

    }
}
