using UnityEngine;


public class Movement : MonoBehaviour
{
    private Controller _controller;

    private Rigidbody _movementRigidbody;


    // 오류 방지를 위한 기본값 입력 (이동 안할때는 제로)
    // 방향
    private Vector3 _movementDirection = Vector3.zero;


    private void Awake()
    {
        _controller = GetComponent<Controller>();
        _movementRigidbody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        // OnMoveEvent 는 입력(방향키)이있을때마다 실행된다
        // OnMoveEvent 에 Move를 호출하라고 등록함
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {

  
        //FixedUpdate 는 물리 업데이트 ApplyMovement() 는 rigidbody 의 값을 변경하니까
        //실제 움직임을 처리
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector3 direction)
    {

        _movementDirection = direction;        
                         
    }

    private void ApplyMovement(Vector3 direction)
    {
        
        direction = direction * 5;
        // 5라는 기본 스피드 숫자가 아니라 characterStatHandler 에서 컨트롤 하는
        // CurrentStat 값을(SO값) 참조하도록 변경했음

        // 백터(direction) 값에 속도를 곱하는 이유는
        // 방향과 속도를 결합하여 객체의 실제 이동 벡터를 계산하기 위함
        //direction = direction * characterStatHandler.CurrentStat.speed;

        // 시작시에는 knockback이 Vector2.zero 라서 움직임에 변화가 없지만
        // 피격시 밀려난다
        //if (knockbackDuration > 0.0f)
        //{
        //    // 방향 좌표가 넉백 좌표만큼 수정된다
        //    // (공격 받은 방향으로 밀림)
        //    direction += knockback;
        //}

        _movementRigidbody.velocity = direction;     

    }

}
