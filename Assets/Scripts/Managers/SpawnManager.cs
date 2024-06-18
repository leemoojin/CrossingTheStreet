using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    // 지금 몇개 생성 했는지
    public int currentSpawnCount = 0;
    // 몇개 생성해야하는지
    public int allSpawnCount;
    
    // 몇초마다 생성 하는지
    //public float spawnInterval = .5f;
    // 어떤 애들을 생성하는지
    //public List<GameObject> enemyPrefebs = new List<GameObject>();


    // 차가 생성되는 위치를 정할것이다 - 부모오브젝트    
    [SerializeField] private Transform spawnPositionsRoot;
    // spawnPositions 에 자식을 등록
    private List<Transform> spawnPositions = new List<Transform>();

    private void Awake()
    {
        

        // 생성위치를 하나하나 다 등록해놓고 쓰는 것보다 같은 부모 아래에 두고 부모하나만 등록해서 사용
        // spawnPositionsRoot 오브젝트 자식으로 생성 위치 오브젝트를 미리 만들어둔 만큼 리스트에 추가된다(2개)
        for (int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            // GetChild() 가 Transform 을 반환한다
            spawnPositions.Add(spawnPositionsRoot.GetChild(i));
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"SpawnManger.cs - Start()");
      
        StartCoroutine(SpawnCars());
        //SpawnCars();
    }


    IEnumerator SpawnCars()
    {
        //Debug.Log($"SpawnManger.cs - SpawnCars()");

        while (true)
        {
            // 플레이 중이 아니라면 차 스폰 정지
            if (!GameManager.Instance.isPlaying)
            {
                yield return new WaitUntil(GameManager.Instance.ReturnIsPlaying);
            }

            int randomCar = Random.Range(0, 2);
            //Debug.Log($"SpawnManger.cs - SpawnCars() - while, currentSpawnCount: {currentSpawnCount}, randomCar: {randomCar}, time: {Time.time}");


            // 정해둔 양만큼 생성이 끝날때까지 무한 반복
            if (allSpawnCount > currentSpawnCount)
            {
                SpawnCar(randomCar);

                // 차동차 생성 텀                
                float spawnInterval = Random.Range(0.3f, 1.2f);
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                // 모든 차가 생성되었을때
                //Debug.Log($"SpawnManger.cs - SpawnCars() - 모든 차가 생성되었습니다, currentSpawnCount: {currentSpawnCount} time: {Time.time}");
                // 현재 생성된 차가 목표 수에 도달했으므로 코루틴을 잠시 중단
                // 필요에 따라 일정 시간 대기 후 다시 시작할 수 있습니다.
                yield return new WaitForSeconds(1f); // 1초 대기 후 재시작
            }
            // currentSpawnCount 가 allSpawnCount와 같아졌을 때 유니티가 정지해버리는 문제 발생**
            // yield return null은 1프레임 뒤 - 이게 없으면 에러발생 
            // currentSpawnCount가 allSpawnCount와 같아졌을 때 무한 루프가 발생하지 않도록 함
            yield return null;
        }
    }

    // SpawnCar를 할때 오브젝트 풀의 차 프리펩을 충분히 만들어 두지 않으면
    // 재활용 되기때문에 currentSpawnCount 만 올라가는 문제가 발생한다
    private void SpawnCar(float num)
    {
        GameObject obj;

        if (num == 0)
        {
            // 빨간 차
            string carTag = ObjectPool.Instance.Pools[0].tag;
            Transform carPos = spawnPositions[0].transform;

            // 오브젝트 풀을 이용해서 차 세팅
            // Tag 을 확인하고 생성을 해라
            obj = ObjectPool.Instance.SpawnFromPool(carTag);
            // 차 위치 세팅
            obj.transform.position = carPos.position;
            obj.SetActive(true);
            //Debug.Log($"SpawnManger.cs - SpawnCars() - 차 생성, currentSpawnCount: {currentSpawnCount} time: {Time.time}");


        }
        else 
        {
            // 노란 버스
            string carTag = ObjectPool.Instance.Pools[1].tag;
            Transform carPos = spawnPositions[1].transform;

            // 오브젝트 풀을 이용해서 차 세팅
            // Tag 을 확인하고 생성을 해라
            obj = ObjectPool.Instance.SpawnFromPool(carTag);
            // 차 위치 세팅
            obj.transform.position = carPos.position;
            obj.SetActive(true);            
            //Debug.Log($"SpawnManger.cs - SpawnCars() - 차 생성, currentSpawnCount: {currentSpawnCount} time: {Time.time}");

        }

        // 생성한 차 오브젝트에 자신을 소환한 SpawnManager가 누군지 등록
        CarController car = obj.GetComponent<CarController>();
        if (car != null)
        {
            car.SetSpawnManager(this);
            currentSpawnCount++;

        }

    }


    public void DecrementSpawnCount()
    {
        currentSpawnCount--;
    }
}
