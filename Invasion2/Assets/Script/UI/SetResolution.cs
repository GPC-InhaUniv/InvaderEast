using UnityEngine;

/// <summary>
/// 담당자 : 김정수
/// Scene의 해상도를 고정하는 부분을 찾고 있었으나
/// 제대로 동작하지 않는다. 
/// 이후 테스트 후 필요 없다면 삭제 요망
/// </summary>

public class SetResolution : MonoBehaviour {
 
    // Use this for initialization
    void Start () {
       Screen.SetResolution(1080, 1920, false);
    }

}
