

[System.Serializable]
public class GameData : Singleton<GameData>
{
    protected GameData() { } // 싱글톤이기 때문에 생성자는 사용할 수 없다.
    public int PlayerHaveGold;
    public int MaxScore;
}
