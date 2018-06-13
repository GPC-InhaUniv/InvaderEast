using UnityEngine;
/// <summary>
/// 각 싱글톤들의 중재자.
/// SceneController는 SceneManager라는 예약어가 존재하기에...
/// </summary>
public class GameMediator : MonoBehaviour
{

    GameDataManager gameDataManager;
    ItemManager itemMangager;
    SceneController sceneController;
    InputManager inputManagere;
    StageManager stageManager;
    PoolManager poolManager;
    SaveAndLoader saveAndload;
    Character player;
    // Use this for initialization


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameDataManager = GameDataManager.Instance;
        itemMangager = ItemManager.Instance;
        sceneController = SceneController.Instance;
        inputManagere = InputManager.Instance;
        stageManager = StageManager.Instance;
        //세이브로더는 싱글톤만 생성
        saveAndload = SaveAndLoader.Instance;
       // poolManager = PoolManager.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }
   
    //게임 데이터와 플레이어의 데이터 읽기
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
        gameDataManager.CurrentScore = score;

    }
    /// <summary>
    /// 골드는 변경과 동시에 저장
    /// </summary>
    /// <param name="gold"></param>
    public void ChangeGold(int gold)
    {
        Debug.Log("골드 변경");
        gameDataManager.Gold += gold;
        SaveAndLoader.Instance.SaveData();
        
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
    }

    public void SellItem(ItemType item)
    {
        Debug.Log(item + "판매");
        itemMangager.SellItem(item);
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

    //InputManager에서 플레이어 이동 방향 받아오기
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
        itemMangager.SpawnItem(type, enemyPos);
    }
    //팩토리는 스테이지 매니저가 생성된 이후의 씬에서 생성되기에 장착(?)해주는 메소드가 필요하다.
    public void SetFactory()
    {
        stageManager.SetFactory();
    }

    public void ChangePlayerModel(PlayerType type)
    {
        Player playerModel = player as Player;
        playerModel.ChangePlayer(type);
    }
}
