using UnityEngine;
/// <summary>
/// 담당자 : 김정수
///
///캡슐화 진행 필요 
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

    public void EndGame()
    {
        currentScore = 0;
        SaveAndLoader.Instance.SaveData();
    }
    
}
