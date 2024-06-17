using UnityEngine;


public class Movement : MonoBehaviour
{
    private Controller _controller;

    private Rigidbody _movementRigidbody;
    private CharacterStatHandler _characterStatHandler;


    // ���� ������ ���� �⺻�� �Է� (�̵� ���Ҷ��� ����)
    // ����
    private Vector3 _movementDirection = Vector3.zero;


    private void Awake()
    {
        //Debug.Log($"Movement.cs - Awake()");

        _controller = GetComponent<Controller>();
        _movementRigidbody = GetComponent<Rigidbody>();
        // CurrentStat �� �������� ���� CharacterStatHandler �� ����
        _characterStatHandler = GetComponent<CharacterStatHandler>();

    }

    private void Start()
    {
        Debug.Log($"Movement.cs - Start()");

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

    // player �ǰ�� playerInputController ���� ������ ������
    private void Move(Vector3 direction)
    {
        Debug.Log($"Movement.cs - Move() - direction: {direction}");
        _movementDirection = direction;        
                         
    }

    private void ApplyMovement(Vector3 direction)
    {
        //Debug.Log($"Movement.cs - ApplyMovement() - direction: {direction}");
                
        // ����(direction) ���� �ӵ��� ���ϴ� ������
        // ����� �ӵ��� �����Ͽ� ��ü�� ���� �̵� ���͸� ����ϱ� ����
        direction = direction * _characterStatHandler.CurrentStat.statSO.speed;

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
