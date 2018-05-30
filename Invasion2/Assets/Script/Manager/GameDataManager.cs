using UnityEngine;
public class GameDataManager : Singleton<GameDataManager>{

    public GameMediator gameMediator;
    protected GameDataManager() {
       
   }
    public int Gold;
    public int MaxScore;
    public int CurrentScore;

    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }
}
