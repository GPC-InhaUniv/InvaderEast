using UnityEngine;

public class GameMediator : MonoBehaviour
{

    GameDataManager gameDataManager;
    ItemManager itemMangager;
    SceneController sceneController;
    InputManager inputManagere;
    Character player;
    // Use this for initialization

   
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameDataManager = GameDataManager.Instance;
        itemMangager = ItemManager.Instance;
        sceneController = SceneController.Instance;
        inputManagere = InputManager.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    public int ReadPlayerGold()
    {
        return gameDataManager.Gold;
    }
    public int ReadPlayerMaxScore()
    {
        return gameDataManager.MaxScore;
    }
    public int ReadPlayerLife()
    {
        return player.CurrentLife;
    }
    public int ReadCurrentScore()
    {
        return gameDataManager.CurrentScore;
    }
    public int ReadPlayerPower()
    {
        return player.Damage;
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
            if (gameDataManager.MaxScore <= gameDataManager.CurrentScore)
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
        Debug.Log("골드 변경");
        gameDataManager.Gold += gold;
       // SaveAndLoader.SaveData();
    }
    /// <summary>
    /// Item 종류 : PowerItem, LifeItem, GoldItem,ScoreItem,MagnaticItem, PowerRegenItem
    /// count : 골드, 스코어 아이템의 골드량 및 스코어양
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void GetItem(ItemType item, int count)
    {
        itemMangager.GetItem(item, count);
    }
    public void GetItem(ItemType item)
    {
        itemMangager.GetItem(item);
    }

    public void BuyItem(ItemType item)
    {
        Debug.Log(item + "구입");
        itemMangager.BuyItem(item);
      //  SaveAndLoader.SaveData();
    }

    public void SellItem(ItemType item)
    {
        Debug.Log(item + "판매");
        itemMangager.SellItem(item);
      //  SaveAndLoader.SaveData();
    }
    
    /// <summary>
    /// 캐릭터 파워,최대 체력 변경
    /// </summary>
    /// <param name="count"></param>
    public void ChangePlayerPower(int count)
    {
       
        player.Damage += count;
    }
    public void ChangePlayerLife(int count)
    {
      player.MaxLife += count;
    }
     

    public void PlayerMove(Vector3 direction)
    {
        player.DirectionToMove(direction);
        
    }

    public void PlayerAttack(bool CheckedAttack)
    {
        player.Attacking = CheckedAttack;
    }

    public void ChangeScene(SceneState state)
    {
        sceneController.ChangeScene(state);
    }

    public void PlayerEquipMainWeapon(IMainAttackable MainWeapon)
    {
        
        Player playerWeapon = player as Player;
        playerWeapon.EquipMainAttack(MainWeapon);
    }

    public void PlayerEquipSubWeapon(ISubAttackable SubWeapon)
    {
        Player playerWeapon = player as Player;
        playerWeapon.EquipSubAttack(SubWeapon);
    }

    public void SpawnItem(ItemType type, Transform enemyPos)
    {
        itemMangager.SpawnItem(type,enemyPos);
    }
}
