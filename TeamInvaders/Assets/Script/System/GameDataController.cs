using UnityEngine;

public enum Difficulty
{
    Easy,
    Normal,
    Hard,
}
public enum ShipType
{
    Red,
    Yello,
    Green,
}
public class GameDataController : MonoBehaviour 
{
    /// <summary>
    /// 게임데이터 접근시 아래 프로퍼티를 사용하여 접근하세요!
    /// 직접 GameData.cs를 함부로 만지 마세요
    /// 데이터 변경시 변경되었다는 Log를 Console창에 출력합니다.
    /// </summary>

    public int PlayerHaveGold { get { return GameData.Instance.PlayerHaveGold; } set { GameData.Instance.PlayerHaveGold = value; ChangeDatas(); } } 
    public int MaxScore { get { return GameData.Instance.MaxScore; } set { GameData.Instance.MaxScore = value; ChangeDatas(); } }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void ChangeDatas()
    {
        Debug.Log("값 변경됨");
    }
  

}
