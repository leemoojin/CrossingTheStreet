using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public event Action<Vector3> OnMoveEvent;


   
    //OnMove() �̺�Ʈ�� �߻������� Invoke �ϴ� ����
    public void CallMoveEvent(Vector3 direction)
    {
        //?. ������ ���� ������ ����
        OnMoveEvent?.Invoke(direction);
    }
}
