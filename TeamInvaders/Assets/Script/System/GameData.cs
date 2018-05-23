
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
[System.Serializable]
public class GameData : Singleton<GameData>
{
    protected GameData() { } // 싱글톤이기 때문에 생성자는 사용할 수 없다.
    public int PlayerDamage;
    public int PlayerHaveGold;
    public Difficulty Difficulte;
    public ShipType PlayerShipType;
    public bool PowerItem;
    public bool LifeItem;
    public bool UltimateItem;
    public bool MagnaticItem;

}
