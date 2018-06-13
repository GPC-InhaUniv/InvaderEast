using UnityEngine;
/// <summary>
/// 담당자 : 김정수
/// 
/// 아이템 오브젝트에 장착될 간단한 정보를 가진 클래스
/// Gold와 Score 아이템은 생성시에 1 ~ 몬스터가 줄수 있는 최대 값사이의 랜덤값이 넣어진다.
/// </summary>

public class Item : MonoBehaviour {
    public ItemType ItemType;
    public int Gold;
    public int Score;
}
