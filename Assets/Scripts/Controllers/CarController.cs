using UnityEngine;

public class CarController : Controller
{
    private CharacterStatHandler _carStatHandler;

    private void Awake()
    {
        _carStatHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
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
            }
        }
        else 
        {
            if (transform.position.x <= -12)
            {
                // ����� ���� ������Ʈ ����
                gameObject.SetActive(false);
            }
        }
    }


}
