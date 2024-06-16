using UnityEngine;


public class Movement : MonoBehaviour
{
    private Controller _controller;

    private Rigidbody _movementRigidbody;


    // ���� ������ ���� �⺻�� �Է� (�̵� ���Ҷ��� ����)
    // ����
    private Vector3 _movementDirection = Vector3.zero;


    private void Awake()
    {
        _controller = GetComponent<Controller>();
        _movementRigidbody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        // OnMoveEvent �� �Է�(����Ű)������������ ����ȴ�
        // OnMoveEvent �� Move�� ȣ���϶�� �����
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {

  
        //FixedUpdate �� ���� ������Ʈ ApplyMovement() �� rigidbody �� ���� �����ϴϱ�
        //���� �������� ó��
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector3 direction)
    {

        _movementDirection = direction;        
                         
    }

    private void ApplyMovement(Vector3 direction)
    {
        
        direction = direction * 5;
        // 5��� �⺻ ���ǵ� ���ڰ� �ƴ϶� characterStatHandler ���� ��Ʈ�� �ϴ�
        // CurrentStat ����(SO��) �����ϵ��� ��������

        // ����(direction) ���� �ӵ��� ���ϴ� ������
        // ����� �ӵ��� �����Ͽ� ��ü�� ���� �̵� ���͸� ����ϱ� ����
        //direction = direction * characterStatHandler.CurrentStat.speed;

        // ���۽ÿ��� knockback�� Vector2.zero �� �����ӿ� ��ȭ�� ������
        // �ǰݽ� �з�����
        //if (knockbackDuration > 0.0f)
        //{
        //    // ���� ��ǥ�� �˹� ��ǥ��ŭ �����ȴ�
        //    // (���� ���� �������� �и�)
        //    direction += knockback;
        //}

        _movementRigidbody.velocity = direction;     

    }

}
