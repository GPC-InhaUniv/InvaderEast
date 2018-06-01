using UnityEngine;

public class GameMediator : MonoBehaviour
{

    GameDataManager gameDataManager;
    ItemManager itemMangager;
    SceneController sceneController;
    InputManager inputManagere;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameDataManager = GameDataManager.Instance;
        itemMangager = ItemManager.Instance;
        sceneController = SceneController.Instance;
        inputManagere = InputManager.Instance;
    }
    /// <summary>
    /// 게임 오버시 score 값 0 입력
    /// </summary>
    /// <param name="score"></param>
    public void ChangeScore(int score)
    {
        if (score == 0)
            gameDataManager.CurrentScore = 0;
        else
        {
            gameDataManager.CurrentScore += score;
            if(gameDataManager.MaxScore <= gameDataManager.CurrentScore)
            {
                gameDataManager.MaxScore = gameDataManager.CurrentScore;
            }
        } 

    }
    /// <summary>
    /// 골드는 변경과 동시에 저장
    /// </summary>
    /// <param name="gold"></param>
    public void ChangeGold(int gold)
    {
        gameDataManager.Gold = gold;
        SaveAndLoader.SaveData();
    }
    /// <summary>
    /// Item 종류 : PowerItem, LifeItem, GoldItem,ScoreItem,MagnaticItem, PowerRegenItem
    /// count : 골드, 스코어 아이템의 골드량 및 스코어양
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void GetItem(Item item,int count)
    {
        itemMangager.GetItem(item, count);
    }
    public void GetItem(Item item)
    {
        itemMangager.GetItem(item);
    }

}
