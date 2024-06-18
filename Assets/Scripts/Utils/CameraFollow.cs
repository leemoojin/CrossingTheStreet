using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 추적할 대상 오브젝트 - 플레이어
    public Transform target;

    // 카메라와 대상 오브젝트 사이의 거리
    public Vector3 offset;

    // 카메라 이동 속도 - 느릴수록 천천히 따라옴
    public float smoothSpeed = 0.025f;

    private void Start()
    {
        if (target != null)
        {
            //float distance = Vector3.Distance(transform.position, target.position);
            Debug.Log($"target: {target.position}");
            Debug.Log($"camera: {transform.position}");
            // 카메라와 플레이어의 좌표 차이
            offset = transform.position - target.position;

        }
    }

    private void LateUpdate()
    {
        // 목표 위치 계산
        Vector3 desiredPosition = target.position + offset;

        // 현재 위치와 목표 위치 사이를 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 카메라 위치 업데이트
        transform.position = smoothedPosition;

        // 카메라가 항상 대상 오브젝트를 바라보도록 설정 (선택 사항)
        //transform.LookAt(target);
    }
}
