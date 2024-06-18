using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    // ���� � ���� �ߴ���
    public int currentSpawnCount = 0;
    // � �����ؾ��ϴ���
    public int allSpawnCount;
    
    // ���ʸ��� ���� �ϴ���
    //public float spawnInterval = .5f;
    // � �ֵ��� �����ϴ���
    //public List<GameObject> enemyPrefebs = new List<GameObject>();


    // ���� �����Ǵ� ��ġ�� ���Ұ��̴� - �θ������Ʈ    
    [SerializeField] private Transform spawnPositionsRoot;
    // spawnPositions �� �ڽ��� ���
    private List<Transform> spawnPositions = new List<Transform>();

    private void Awake()
    {
        

        // ������ġ�� �ϳ��ϳ� �� ����س��� ���� �ͺ��� ���� �θ� �Ʒ��� �ΰ� �θ��ϳ��� ����ؼ� ���
        // spawnPositionsRoot ������Ʈ �ڽ����� ���� ��ġ ������Ʈ�� �̸� ������ ��ŭ ����Ʈ�� �߰��ȴ�(2��)
        for (int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            // GetChild() �� Transform �� ��ȯ�Ѵ�
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
            // �÷��� ���� �ƴ϶�� �� ���� ����
            if (!GameManager.Instance.isPlaying)
            {
                yield return new WaitUntil(GameManager.Instance.ReturnIsPlaying);
            }

            int randomCar = Random.Range(0, 2);
            //Debug.Log($"SpawnManger.cs - SpawnCars() - while, currentSpawnCount: {currentSpawnCount}, randomCar: {randomCar}, time: {Time.time}");


            // ���ص� �縸ŭ ������ ���������� ���� �ݺ�
            if (allSpawnCount > currentSpawnCount)
            {
                SpawnCar(randomCar);

                // ������ ���� ��                
                float spawnInterval = Random.Range(0.3f, 1.2f);
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                // ��� ���� �����Ǿ�����
                //Debug.Log($"SpawnManger.cs - SpawnCars() - ��� ���� �����Ǿ����ϴ�, currentSpawnCount: {currentSpawnCount} time: {Time.time}");
                // ���� ������ ���� ��ǥ ���� ���������Ƿ� �ڷ�ƾ�� ��� �ߴ�
                // �ʿ信 ���� ���� �ð� ��� �� �ٽ� ������ �� �ֽ��ϴ�.
                yield return new WaitForSeconds(1f); // 1�� ��� �� �����
            }
            // currentSpawnCount �� allSpawnCount�� �������� �� ����Ƽ�� �����ع����� ���� �߻�**
            // yield return null�� 1������ �� - �̰� ������ �����߻� 
            // currentSpawnCount�� allSpawnCount�� �������� �� ���� ������ �߻����� �ʵ��� ��
            yield return null;
        }
    }

    // SpawnCar�� �Ҷ� ������Ʈ Ǯ�� �� �������� ����� ����� ���� ������
    // ��Ȱ�� �Ǳ⶧���� currentSpawnCount �� �ö󰡴� ������ �߻��Ѵ�
    private void SpawnCar(float num)
    {
        GameObject obj;

        if (num == 0)
        {
            // ���� ��
            string carTag = ObjectPool.Instance.Pools[0].tag;
            Transform carPos = spawnPositions[0].transform;

            // ������Ʈ Ǯ�� �̿��ؼ� �� ����
            // Tag �� Ȯ���ϰ� ������ �ض�
            obj = ObjectPool.Instance.SpawnFromPool(carTag);
            // �� ��ġ ����
            obj.transform.position = carPos.position;
            obj.SetActive(true);
            //Debug.Log($"SpawnManger.cs - SpawnCars() - �� ����, currentSpawnCount: {currentSpawnCount} time: {Time.time}");


        }
        else 
        {
            // ��� ����
            string carTag = ObjectPool.Instance.Pools[1].tag;
            Transform carPos = spawnPositions[1].transform;

            // ������Ʈ Ǯ�� �̿��ؼ� �� ����
            // Tag �� Ȯ���ϰ� ������ �ض�
            obj = ObjectPool.Instance.SpawnFromPool(carTag);
            // �� ��ġ ����
            obj.transform.position = carPos.position;
            obj.SetActive(true);            
            //Debug.Log($"SpawnManger.cs - SpawnCars() - �� ����, currentSpawnCount: {currentSpawnCount} time: {Time.time}");

        }

        // ������ �� ������Ʈ�� �ڽ��� ��ȯ�� SpawnManager�� ������ ���
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
