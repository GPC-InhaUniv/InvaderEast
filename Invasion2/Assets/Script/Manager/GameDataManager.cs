using UnityEngine;
/// <summary>
/// 담당자 : 김정수
///
///캡슐화 진행 필요 
/// </summary>
public class GameDataManager : Singleton<GameDataManager>{

   // GameMediator gameMediator;
    protected GameDataManager() { }
    public int Gold;
    public int MaxScore;
    public int CurrentScore;
    /*
    public int Gold { get { return gold; } private set { }}
    public int MaxScore { get { return maxScore; } set { maxScore = value; } }
    public int CurrentScore { get { return currentScore; }private set { } }
    public void ChangeGold(int gold)
    {
        this.gold += gold;
    }
   
    public void ChangeScore(int score)
    {
        this.currentScore = score;
        if(currentScore >= maxScore)
        {
            maxScore = currentScore;
        }
    }
    */
    private void Start()
    {
        // gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        
    }

    
}
