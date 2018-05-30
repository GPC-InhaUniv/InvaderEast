using UnityEngine;
public class GameDataManager : Singleton<GameDataManager>{

    protected GameDataManager() { }
    public int Gold;
    public int MaxScore;
    public int CurrentScore;
}
