using UnityEngine;

public class CarController : Controller
{
    private CharacterStatHandler _carStatHandler;

    //��� ���� �������� ����
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
        // ���ʿ� �ִ� �ڵ����� ��� -> ���������� �̵�
        if (_carStatHandler.CurrentStat.statSO.isLeft)
        {
            //Debug.Log($"CarController.cs - OnMove() - ����");

            // ������Ʈ�� y���� �߽����� 90�� ȸ��
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

        // ���ʿ� �ִ� �ڵ����� ���
        if (_carStatHandler.CurrentStat.statSO.isLeft)
        {
            if (transform.position.x >= 12)
            {
                // ����� ���� ������Ʈ ����
                gameObject.SetActive(false);

                // SpawnManager���� ���� ��ȯ�� �� ���ڸ� ����
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
                // ����� ���� ������Ʈ ����
                gameObject.SetActive(false);
                
                if (_spawnManager != null)
                {
                    _spawnManager.DecrementSpawnCount();
                }

            }
        }
    }

    // �浹��
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�浹");

        // �浿�� ������Ʈ�� �������� üũ
        GameObject receiver = collision.gameObject;

        int player = LayerMask.NameToLayer("Player");

        // �÷��̾ �ƴҰ�� ����
        if (receiver.layer != player)
        {
            return;
        }

        GameManager.Instance.GameOver();
    }

    // �ڽ��� ��ȯ�� SpawnManager�� ���
    public void SetSpawnManager(SpawnManager manager)
    {
        _spawnManager = manager;
    }

 }
