using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : Controller 
{
    // 인풋액션(이동)에서 받아온 값
    private Vector3 _curMovementInput;


    public void OnMoveInput(InputAction.CallbackContext context)
    {

        // context.phase 는 입력의 현재상태를 받아온다
        // InputActionPhase.Started 처음 버튼을 입력했을 때
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log($"PlayerInputController.cs - OnMoveInput() - context.phase: {context.phase}, context.ReadValue<Vector3>(): {context.ReadValue<Vector3>()}, context: {context}");
            _curMovementInput = context.ReadValue<Vector3>().normalized;


            CallMoveEvent(_curMovementInput);

        }

        // 입력이 끝났을 때 - 키보드 입력의 경우 Canceled 이 호출 안됨
        if (context.phase == InputActionPhase.Canceled)
        {
            //_isMoving = false;
            Debug.Log($"PlayerInputController.cs - OnMoveInput() - context.phase: {context.phase}");
            _curMovementInput = Vector3.zero;


        }       
    }


}
