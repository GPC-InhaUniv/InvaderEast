using UnityEngine;


public class GameDataController : MonoBehaviour 
{
    /// <summary>
    /// 게임데이터 접근시 아래 프로퍼티를 사용하여 접근하세요!
    /// 직접 GameData.cs를 함부로 만지 마세요
    /// 데이터 변경시 변경되었다는 Log를 Console창에 출력합니다.
    /// </summary>
    public int PlayerDamage { get { return GameData.Instance.PlayerDamage; } set { GameData.Instance.PlayerDamage = value; ChangeDatas(); } }
    public int PlayerHaveGold { get { return GameData.Instance.PlayerHaveGold; } set { GameData.Instance.PlayerHaveGold = value; ChangeDatas(); } } 
    public Difficulty Difficulte { get { return GameData.Instance.Difficulte; } set { GameData.Instance.Difficulte = value; ChangeDatas(); } }
    public ShipType PlayerShipType { get { return GameData.Instance.PlayerShipType; } set{ GameData.Instance.PlayerShipType = value; ChangeDatas(); } }
    public bool PowerItem{ get { return GameData.Instance.PowerItem; } set { GameData.Instance.PowerItem = value; ChangeDatas(); } }
    public bool LifeItem{get { return GameData.Instance.LifeItem; } set { GameData.Instance.LifeItem = value; ChangeDatas(); } }  
    public bool UltimateItem { get { return GameData.Instance.UltimateItem; } set { GameData.Instance.UltimateItem = value; ChangeDatas(); } }
    public bool MagnaticItem { get { return GameData.Instance.MagnaticItem; } set { GameData.Instance.MagnaticItem = value; ChangeDatas(); } }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeDatas()
    {
        Debug.Log("값 변경됨");
    }
  

}
