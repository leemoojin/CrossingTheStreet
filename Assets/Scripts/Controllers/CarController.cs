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
            }
        }
        else 
        {
            if (transform.position.x <= -12)
            {
                // 사용이 끝난 오브젝트 끄기
                gameObject.SetActive(false);
            }
        }
    }


}
