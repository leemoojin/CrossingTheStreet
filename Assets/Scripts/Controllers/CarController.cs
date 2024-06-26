using UnityEngine;

public class CarController : Controller
{
    private CharacterStatHandler _carStatHandler;

    //어디서 차가 생성될지 지정
    [SerializeField] private Transform _carSpawnPosition;

    private SpawnManager _spawnManager;

    private void Awake()
    {
        _carStatHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        //Debug.Log($"CarController.cs - Start()");

        OnMove();
    }

    private void Update()
    {
        DestroyCar();
    }

    private void OnMove()
    {
        // 왼쪽에 있는 자동차일 경우 -> 오른쪽으로 이동
        if (_carStatHandler.CurrentStat.statSO.isLeft)
        {
            //Debug.Log($"CarController.cs - OnMove() - 왼쪽");

            // 오브젝트를 y축을 중심으로 90도 회전
            transform.rotation = Quaternion.Euler(0, 90, 0);
            CallMoveEvent(new Vector3(1, 0, 0));
        }
        else 
        {            
            transform.rotation = Quaternion.Euler(0, -90, 0);
            CallMoveEvent(new Vector3(-1, 0, 0));
        }

    }

    private void DestroyCar()
    {
        //Debug.Log($"CarController.cd - DestroyCar() - transform.position.x: {transform.position.x}");

        // 왼쪽에 있는 자동차일 경우
        if (_carStatHandler.CurrentStat.statSO.isLeft)
        {
            if (transform.position.x >= 12)
            {
                // 사용이 끝난 오브젝트 끄기
                gameObject.SetActive(false);

                // SpawnManager에서 현재 소환된 차 숫자를 감소
                if (_spawnManager != null)
                {
                    _spawnManager.DecrementSpawnCount();
                }
            }
        }
        else 
        {
            if (transform.position.x <= -12)
            {
                // 사용이 끝난 오브젝트 끄기
                gameObject.SetActive(false);
                
                if (_spawnManager != null)
                {
                    _spawnManager.DecrementSpawnCount();
                }

            }
        }
    }

    // 충돌시
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");

        // 충동한 오브젝트가 무엇인지 체크
        GameObject receiver = collision.gameObject;

        int player = LayerMask.NameToLayer("Player");

        // 플레이어가 아닐경우 무시
        if (receiver.layer != player)
        {
            return;
        }

        GameManager.Instance.GameOver();
    }

    // 자신을 소환한 SpawnManager를 등록
    public void SetSpawnManager(SpawnManager manager)
    {
        _spawnManager = manager;
    }

 }
