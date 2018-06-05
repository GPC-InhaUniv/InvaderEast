using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 화면을 터치한 부분의 좌표값을 받아
/// Character로 넘겨주는 역할을 해주는 부분
/// </summary>
public class MoveController : MonoBehaviour
{
    Player player;

    protected Transform Stick;
    protected Transform StickPannel;
    protected Vector3 centerPos;
    protected Vector3 directionPos;
    Vector3 touchPos;
    float StickRadius = 30f;
    float pannelRaius;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        Stick = GameObject.FindWithTag("JoyStick").GetComponent<RectTransform>();
        Stick.gameObject.SetActive(false);
        StickPannel = GameObject.FindWithTag("StickPannel").GetComponent<RectTransform>();
        pannelRaius = GetComponent<RectTransform>().sizeDelta.y / 2;
    }

    private void Update()
    {
        /*if(Input.GetMouseButton(0))
        {
            StickMove();
        }*/
    }

    public void CenterPos()
    {
        Stick.gameObject.SetActive(true);
        touchPos = Input.mousePosition;
        centerPos = touchPos;
        StickPannel.position = centerPos;
        Debug.Log("좌표 : " + centerPos);
        Debug.Log("패널 좌표 : " + StickPannel.position);
    }


    public void StickMove()
    {
        Vector3 dragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        directionPos = (dragPos - centerPos).normalized;
        Debug.Log("드래그 좌표 : " + dragPos);

        player.Move(directionPos);

        //Debug.Log("방향 : " + directionPos);
        float stickDistance = Vector3.Distance(dragPos, centerPos);
        if (stickDistance > StickRadius)
        {
            //touchPos = centerPos + directionPos * pannelRaius;
            Stick.position = centerPos + directionPos * StickRadius;
            Debug.Log("너 어디갔냐 : " + Stick.position);
        }
        else
        {
            //touchPos = centerPos + directionPos * stickDistance;
            Stick.position = centerPos + directionPos * stickDistance;
            Debug.Log("너 어디갔냐 : " + Stick.position);
        }
    }

    public void StickMoveEnd()
    {
        //direction = Direction.STOP;
        player.Move(Direction.STOP);
        Stick.position = centerPos;
        directionPos = Vector3.zero;
        Stick.gameObject.SetActive(false);
    }
}
