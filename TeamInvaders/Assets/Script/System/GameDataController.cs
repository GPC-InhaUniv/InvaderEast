using UnityEngine;


public class GameDataController : MonoBehaviour 
{
    /// <summary>
    /// 게임데이터 접근시 아래 프로퍼티를 사용하여 접근하세요!
    /// 직접 GameData.cs를 함부로 만지 마세요
    /// 데이터 변경시 변경되었다는 Log를 Console창에 출력합니다.
    /// </summary>
  
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
    private int playerDamage;
    private int playerLife;
    private bool playerShild;
    private bool powerItem;
    private bool lifeItem;
    private bool magnaticItem;
    private ShipType playerShip;
    private Difficulty difficulte;

    public int PlayerDamage { get { return playerDamage; } set { playerDamage = value;ChangeDatas(); } }
    public int PlayerLife { get { return playerLife; } set { playerLife = value; ChangeDatas(); } }
    public bool PlayerShild { get { return playerShild; } set { playerShild = value; ChangeDatas(); } }
    public bool PowerItem { get { return powerItem; } set { powerItem = value; ChangeDatas(); } }
    public bool LifeItem { get { return lifeItem; } set { lifeItem = value; ChangeDatas(); } }
    public bool MagnaticItem { get { return magnaticItem; } set { magnaticItem = value; ChangeDatas(); } }
    public int PlayerHaveGold { get { return GameData.Instance.PlayerHaveGold; } set { GameData.Instance.PlayerHaveGold = value; ChangeDatas(); } } 
    public int MaxCount { get { return GameData.Instance.MaxScore; } set { GameData.Instance.MaxScore = value; ChangeDatas(); } }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeDatas()
    {
        Debug.Log("값 변경됨");
    }
  

}
