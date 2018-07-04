using UnityEngine;
/// <summary>
/// 담당자 : 김정수
/// </summary>
public class GameDataManager : Singleton<GameDataManager>{

   // GameMediator gameMediator;
    protected GameDataManager() { }
    private int gold;
    private int maxScore;
    private int currentScore;
    
    public int Gold { get { return gold; } }
    public int MaxScore { get { return maxScore; }  }
    public int CurrentScore { get { return currentScore; } }

    private void Start()
    {
        GameMediator.Instance.DoGameOver += new GameMediator.DoGameOverDelegate(EndGame);
    }
    public void ChangeGold(int gold)
    {
        this.gold += gold;
    }
   
    public void ChangeScore(int score)
    {
        currentScore += score;
        if(currentScore >= maxScore)
        {
            maxScore = currentScore;
        }
    }
    public void ChangeMaxScore(int score)
    {
        maxScore = score;
    }
    private void EndGame()
    {
        currentScore = 0;
        SaveAndLoader.Instance.SaveData();
    }
    
}
