﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// --------------------------------------------------
/// 담당자 : 박상원
/// 
/// 화면을 터치한 부분의 좌표값과
/// 이동방향을 GameMediator에 전달해주면
/// GameMediator에서 Character 클래스의
/// DirectionToMove 함수에 이동방향 값을 전달.
/// --------------------------------------------------
/// 게임 화면상에 처음에는 보이지 않게 설정해두었고
/// 게임 화면을 터치하면 터치된 좌표를 중심좌표로 하여 
/// 캐릭터 조작 컨트롤러가 표시되며 터치 반응이 없을 경우
/// 캐릭터 조작 컨트롤러가 다시 숨겨진다.
/// -------------------------------------------------
/// 이동 패드 반응이 있을 시 Player에게 공격 활성, 
/// 비활성 전환 요청을 보낸다.
/// --------------------------------------------------
/// </summary>
public class MoveController : MonoBehaviour
{
    private RawImage pannelImage;
    private Transform Stick;
    private Transform StickPannel;
    private Vector3 centerPos;
    private Vector3 directionPos;
    private Vector3 touchPos;
    private float StickRadius = 60f;

    private void Start()
    {

        pannelImage = GameObject.FindWithTag("StickPannel").GetComponent<RawImage>();
        pannelImage.enabled = false;
        Stick = GameObject.FindWithTag("JoyStick").GetComponent<RectTransform>();
        Stick.gameObject.SetActive(false);
        StickPannel = GameObject.FindWithTag("StickPannel").GetComponent<RectTransform>();
    }

    public void CenterPos()
    {
        pannelImage.enabled = true;
        Stick.gameObject.SetActive(true);
        touchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        StickPannel.position = touchPos;


        GameMediator.Instance.PlayerMove(Vector3.zero);
        GameMediator.Instance.PlayerAttack(true);
    }


    public void StickMove()
    {
        Vector3 dragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        directionPos = (dragPos - touchPos).normalized;


        GameMediator.Instance.PlayerMove(new Vector3(directionPos.x, 0, directionPos.y));


        float stickDistance = Vector3.Distance(dragPos, touchPos);
        if (stickDistance > StickRadius)
        {
            Stick.position = touchPos + directionPos * StickRadius;
        }
        else
        {
            Stick.position = touchPos + directionPos * stickDistance;
        }
    }

    public void StickMoveEnd()
    {
        directionPos = Vector3.zero;

        GameMediator.Instance.PlayerMove(directionPos);
        GameMediator.Instance.PlayerAttack(false);

        Stick.position = touchPos;
        pannelImage.enabled = false;
        Stick.gameObject.SetActive(false);
    }
}
