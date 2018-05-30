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
    public Transform Stick;
    Vector3 touchPos;
    Vector3 centerPos;
    Vector3 direction;
    float pannelRaius;

    private void Start()
    {
        Stick = GameObject.Find("JoyStick").GetComponent<RectTransform>();
        pannelRaius = GetComponent<RectTransform>().sizeDelta.y / 2;
        Stick.gameObject.SetActive(false);
    }

    /*private void Update()
    {
        StickMove();
    }*/

    
    public void StickMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Stick.gameObject.SetActive(true);
            touchPos = Input.mousePosition;
            centerPos = touchPos;
            this.gameObject.transform.position = centerPos;
            Debug.Log("좌표 : " + touchPos);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 dragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
            direction = (dragPos - centerPos).normalized;
            float stickDistance = Vector3.Distance(dragPos, centerPos);
            if(stickDistance>pannelRaius)
            {
                touchPos = centerPos + direction * pannelRaius;
                Stick.position = centerPos + direction * pannelRaius;
            }
            else
            {
                touchPos = centerPos + direction * stickDistance;
                Stick.position = centerPos + direction * pannelRaius;
            }
            Debug.Log("드래그 중");
        }

        if(Input.GetMouseButtonUp(0))
        {
            StickMoveEnd();
        }
    }

    public void StickMoveEnd()
    {
        Stick.position = centerPos;
        direction = Vector3.zero;
        Stick.gameObject.SetActive(false);
    }
}
