using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ------------------------------------
/// 담당자 : 박상원
/// 화면을 터치한 부분의 좌표값과
/// 이동방향을 Character의 Move 메서드의
/// 매개변수로 넘겨준다.
/// ------------------------------------
/// Player의 공격 활성, 비활성 전환을
/// MoveController 스크립트에서 해준다.
/// ------------------------------------
/// </summary>
public class MoveController : MonoBehaviour
{
    public RawImage pannelImage;
    [SerializeField]
    protected Transform Stick;
    protected Transform StickPannel;
    protected Vector3 centerPos;
    protected Vector3 directionPos;
    Vector3 touchPos;
    float StickRadius = 60f;

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
        touchPos = Input.mousePosition;
        centerPos = touchPos;
        StickPannel.position = centerPos;


        InputManager.Instance.PlayerMove(Vector3.zero);
        InputManager.Instance.PlayerAttack(true);
    }


    public void StickMove()
    {
        Vector3 dragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        directionPos = (dragPos - centerPos).normalized;
        
            InputManager.Instance.PlayerMove(directionPos);
        

        float stickDistance = Vector3.Distance(dragPos, centerPos);
        if (stickDistance > StickRadius)
        {
            Stick.position = centerPos + directionPos * StickRadius;
        }
        else
        {
            Stick.position = centerPos + directionPos * stickDistance;
        }
    }

    public void StickMoveEnd()
    {
        directionPos = Vector3.zero;

        InputManager.Instance.PlayerMove(directionPos);
        InputManager.Instance.PlayerAttack(false);
        
        Stick.position = centerPos;
        pannelImage.enabled = false;
        Stick.gameObject.SetActive(false);
    }
}
