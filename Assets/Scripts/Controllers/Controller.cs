using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public event Action<Vector3> OnMoveEvent;


   
    //OnMove() 이벤트가 발생했을때 Invoke 하는 역할
    public void CallMoveEvent(Vector3 direction)
    {
        //Debug.Log($"Controller.cs - CallMoveEvent() - direction: {direction}");

        //?. 없으면 말고 있으면 실행
        OnMoveEvent?.Invoke(direction);
    }
}
