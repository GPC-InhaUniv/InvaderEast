using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 화면을 터치한 부분의 좌표값을 받아
/// Character로 넘겨주는 역할을 해주는 부분
/// </summary>
public class MoveController : MonoBehaviour
{
    Player player;
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
        player = FindObjectOfType<Player>();
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
        Debug.Log("좌표 : " + centerPos);
        Debug.Log("패널 좌표 : " + StickPannel.position);
    }
  

    public void StickMove()
    {
        Vector3 dragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        directionPos = (dragPos - centerPos).normalized;
        Debug.Log("드래그 좌표 : " + dragPos);

        if (player)
        {
            player.Move(directionPos);
        }
        else
        {
            
        }

        float stickDistance = Vector3.Distance(dragPos, centerPos);
        if (stickDistance > StickRadius)
        {
            Stick.position = centerPos + directionPos * StickRadius;
            Debug.Log("너 어디갔냐 : " + Stick.position);
        }
        else
        {
            Stick.position = centerPos + directionPos * stickDistance;
            Debug.Log("너 어디갔냐 : " + Stick.position);
        }
    }

    public void StickMoveEnd()
    {
        Stick.position = centerPos;
        directionPos = Vector3.zero;
        player.Move(directionPos);
        pannelImage.enabled = false;
        Stick.gameObject.SetActive(false);
    }
}
