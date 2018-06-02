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
        if (directionPos.y > 0.2f)
        {
            //direction = Direction.UP;
            player.Move(Direction.UP);
            //Debug.Log("위쪽 : " + directionPos);
        }
        else if (directionPos.y < -0.2f)
        {
            //direction = Direction.DOWN;
            player.Move(Direction.DOWN);
            //Debug.Log("아래 : " + directionPos);
        }
        else if (directionPos.x < -0.2f)
        {
            //direction = Direction.LEFT;
            player.Move(Direction.LEFT);
            //Debug.Log("왼쪽 : " + directionPos);
        }
        else if (directionPos.x > 0.2f)
        {
            //direction = Direction.RIGHT;
            player.Move(Direction.RIGHT);
            //Debug.Log("오른쪽 : " + directionPos);
        }
        //Debug.Log("방향 : " + directionPos);
        float stickDistance = Vector3.Distance(dragPos, centerPos);
        if (stickDistance > pannelRaius)
        {
            //touchPos = centerPos + directionPos * pannelRaius;
            Stick.position = centerPos + directionPos * pannelRaius;
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
