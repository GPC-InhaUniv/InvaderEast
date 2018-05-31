using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMediator : MonoBehaviour
{

    public GameDataManager gameDatamanager;
    ItemManager itemMangager;
    SceneController sceneController;
    StageManager stageManager;


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameDatamanager = GameDataManager.Instance;
        itemMangager = ItemManager.Instance;
        stageManager = StageManager.Instance;
        sceneController = SceneController.Instance;
    }
    /// <summary>
    /// 게임 오버시 score 값 0 입력
    /// </summary>
    /// <param name="score"></param>
    public void ChangeScore(int score)
    {
        if (score == 0)
            GameDataManager.Instance.CurrentScore = 0;
        else
        {
            GameDataManager.Instance.CurrentScore += score;
            if(GameDataManager.Instance.MaxScore <= GameDataManager.Instance.CurrentScore)
            {
                GameDataManager.Instance.MaxScore = GameDataManager.Instance.CurrentScore;
            }
        } 

    }
    /// <summary>
    /// 골드는 변경과 동시에 저장
    /// </summary>
    /// <param name="gold"></param>
    public void ChangeGold(int gold)
    {
        GameDataManager.Instance.Gold = gold;
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
