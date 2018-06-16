using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// --------------------------------------------------
/// 담당자 : 박상원
/// 화면을 터치한 부분의 좌표값과
/// 이동방향을 Character의 Move 메서드의
/// 매개변수로 넘겨준다.
/// /// Player의 공격 활성, 비활성 전환 또한
/// MoveController 스크립트에서 해준다.
/// --------------------------------------------------
/// 게임 화면상에 처음에는 보이지 않게 설정해두었고
/// 게임 화면을 터치하면 터치된 좌표를 중심좌표로 하여 
/// 캐릭터 조작 컨트롤러가 표시된다.
/// --------------------------------------------------
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
        touchPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
        StickPannel.position = touchPos;


        InputManager.Instance.PlayerMove(Vector3.zero);
        InputManager.Instance.PlayerAttack(true);
    }


    public void StickMove()
    {
        Vector3 dragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0 );
        directionPos = (dragPos - touchPos).normalized;
        Debug.Log("방향 : " + directionPos);
        Debug.Log("센터 좌표 : " + touchPos);
        
            InputManager.Instance.PlayerMove(new Vector3(directionPos.x,0,directionPos.y));
        

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

        InputManager.Instance.PlayerMove(directionPos);
        InputManager.Instance.PlayerAttack(false);
        
        Stick.position = touchPos;
        pannelImage.enabled = false;
        Stick.gameObject.SetActive(false);
    }
}
