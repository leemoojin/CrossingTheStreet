using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 오브젝트 풀 데이터를 정의할 데이터 모음 정의
    [System.Serializable]
    public class Pool
    {
        // 오브젝트 태그
        public string tag;
        // 생성할 프리펩
        public GameObject prefab;
        // 몇개를 생성할건지
        public int size;
    }

    public List<Pool> Pools;
    // 큐로 저장을 해서 가장 먼저 저장한 얘를 주는 방식
    // Dictionary 를 사용해 큐와 구분을 위한 태그와 함께 저장
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        // 인스펙터창의 Pools를 바탕으로 오브젝트풀을 만들 것. 
        // 오브젝트풀은 관리할 프리펩마다 따로
        // pool size를 넘어가면 가장 먼저 활성화된 오브젝트를 끄고 재할당.
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in Pools)
        {
            // 큐는 FIFO(First-in First-out) 구조로서, 줄을 서는 것처럼 가장 오래 줄 선(enqueue) 객체가 가장 먼저 빠져 나올(dequeue) 수 있는 구조
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // Awake하는 순간 오브젝트풀에 들어갈 Instantitate 일어나기 때문에 터무니없는 사이즈 조심                
                // pool 프리펩들이 오브젝트 풀의 자식으로 생성됨
                GameObject obj = Instantiate(pool.prefab, transform);

                obj.SetActive(false);                
                objectPool.Enqueue(obj);
            }
            // 접근이 편한 Dictionary에 등록
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        // 애초에 Pool이 존재하지 않는 경우
        if (!PoolDictionary.ContainsKey(tag)) return null;
        
        // 제일 오래된 객체를 재활용하는 방식
        // 만약 해당 객체가 살아있다면 문제가 발생 
        // 재사용 하기위해 화면에 있는 것을 강제로 없앤다
        // 다른방법으로는 리스트를 사용해서
        // 해당 오브젝트가 사용중인지 확인한다

        //Dequeue 를 통해서 큐목록에서는 빠지지만 
        //오브젝트를 파괴한는것이 아니다
        //다시 큐에 넣어주면 재활용 가능하다        
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        obj.SetActive(true);
        return obj;
    }
}
