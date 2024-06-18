using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // ������ ��� ������Ʈ - �÷��̾�
    public Transform target;

    // ī�޶�� ��� ������Ʈ ������ �Ÿ�
    public Vector3 offset;

    // ī�޶� �̵� �ӵ� - �������� õõ�� �����
    public float smoothSpeed = 0.025f;

    private void Start()
    {
        if (target != null)
        {
            //float distance = Vector3.Distance(transform.position, target.position);
            Debug.Log($"target: {target.position}");
            Debug.Log($"camera: {transform.position}");
            // ī�޶�� �÷��̾��� ��ǥ ����
            offset = transform.position - target.position;

        }
    }

    private void LateUpdate()
    {
        // ��ǥ ��ġ ���
        Vector3 desiredPosition = target.position + offset;

        // ���� ��ġ�� ��ǥ ��ġ ���̸� �ε巴�� �̵�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ī�޶� ��ġ ������Ʈ
        transform.position = smoothedPosition;

        // ī�޶� �׻� ��� ������Ʈ�� �ٶ󺸵��� ���� (���� ����)
        //transform.LookAt(target);
    }
}
