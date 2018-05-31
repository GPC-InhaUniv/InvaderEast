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
    Character character;

    public Transform Stick;
    public Vector3 centerPos;
    public Vector3 directionPos;
    Direction direction;
    Vector3 touchPos;
    float pannelRaius;

    private void Start()
    {
        Stick = GameObject.Find("JoyStick").GetComponent<RectTransform>();
        pannelRaius = GetComponent<RectTransform>().sizeDelta.y / 2;
        Stick.gameObject.SetActive(false);
    }

    private void Update()
    {
        CenterPos();
    }

    void CenterPos()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Stick.gameObject.SetActive(true);
            touchPos = Input.mousePosition;
            centerPos = touchPos;
            this.gameObject.transform.position = centerPos;
            Debug.Log("좌표 : " + touchPos);
        }
    }

    
    public void StickMove()
    {
        Vector3 dragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        directionPos = (dragPos - centerPos).normalized;
        Debug.Log("드래그 좌표 : " + directionPos);
        /*if(directionPos.y>centerPos.y)
        {
            character.Move(Direction.UP);
            Debug.Log("위쪽 : " + directionPos);
        }
        else if(directionPos.y<centerPos.y)
        {
            character.Move(Direction.DOWN);
            Debug.Log("아래 : " + directionPos);
        }
        else if(directionPos.x<centerPos.x)
        {
            character.Move(Direction.LEFT);
        }
        else
        {
            character.Move(Direction.RIGHT);
        }*/
        //Debug.Log("방향 : " + directionPos);
        float stickDistance = Vector3.Distance(dragPos, centerPos);
        if (stickDistance > pannelRaius)
        {
            //touchPos = centerPos + directionPos * pannelRaius;
            Stick.position = centerPos + directionPos * pannelRaius;
        }
        else
        {
            //touchPos = centerPos + directionPos * stickDistance;
            Stick.position = centerPos + directionPos * pannelRaius;
        }
        
    }

    public void StickMoveEnd()
    {
        Stick.position = centerPos;
        directionPos = Vector3.zero;
        Stick.gameObject.SetActive(false);
    }
}
