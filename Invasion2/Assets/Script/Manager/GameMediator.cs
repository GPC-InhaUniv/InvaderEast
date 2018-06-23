using UnityEngine;
/// <summary>
/// 담당자 : 김정수
/// 각 싱글톤들의 중재자.
/// </summary>
public class GameMediator : Singleton<GameMediator>
{

    GameDataManager gameDataManager;
    ItemManager itemManager;
    SceneController sceneController;
    InputManager inputManagere;
    StageManager stageManager;
    Character player;
    // Use this for initialization
    SaveAndLoader saveAndLoader;

    private void Awake()
    {
        gameDataManager = GameDataManager.Instance;
        itemManager = ItemManager.Instance;
        sceneController = SceneController.Instance;
        inputManagere = InputManager.Instance;
        stageManager = StageManager.Instance;
        saveAndLoader = SaveAndLoader.Instance;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
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
    public int ReadCurrentScore()
    {
        return gameDataManager.CurrentScore;
    }
    public int ReadPlayerPower()
    {
        return player.Power;
    }
    public int ReadPlayerLife()
    {
        return player.CurrentLife;
    }
    // 게임 오버시 score 값 0 입력
    public delegate void CheckChangeScore();
    public CheckChangeScore CheckedChangeScore;
    public void ChangeScore(int score)
    {  
        gameDataManager.ChangeScore(score);
        CheckedChangeScore();
    }

    // 골드는 변경과 동시에 저장
    public void ChangeGold(int gold)
    {
        Debug.Log("골드 변경");
        gameDataManager.ChangeGold(gold);
        SaveAndLoader.Instance.SaveData();

    }
    public void GameOver()
    {
        GameDataManager.Instance.EndGame();
    }
    // Item 종류 : PowerItem, LifeItem, GoldItem,ScoreItem,MagnaticItem, PowerRegenItem
    // count : 골드, 스코어 아이템의 골드량 및 스코어양
    public void GetItem(ItemType item, int count)
    {
        ItemManager.Instance.GetItem(item, count);
    }
    public void GetItem(ItemType item)
    {
        ItemManager.Instance.GetItem(item);
    }

    public void BuyItem(ItemType item)
    {
        ItemManager.Instance.BuyItem(item);
    }

    public void SellItem(ItemType item)
    {
        ItemManager.Instance.SellItem(item);
    }


    // 캐릭터 파워,최대 체력, 장비, 모델 변경
    public delegate void ChangePower();
    public ChangePower changePower;
    public void ChangePlayerPower(int count)
    {
        player.Power = count;
        changePower();
    }
    public delegate void ChangeLife();
    public ChangeLife changeLife;
    public void ChangePlayerLife(int count)
    {
        player.MaxLife += count;
        changeLife();
    }

    public void ChangePlayerType(PlayerType type)
    {
        Player playerModel = player as Player;
        playerModel.ChangePlayer(type);
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
        SceneController.Instance.ChangeScene(state);
    }

    public void SpawnItem(GameObject enemyPos)
    {
        ItemManager.Instance.SpawnItem(enemyPos);
    }

    //pool manager 관련 메서드
    public GameObject GetEnemyObject()
    {
        return PoolManager.Instance.GetEnemyObject();
    }

    public void PutEnemyObject(GameObject gameObject)
    {
        PoolManager.Instance.PutEnemyObject(gameObject);
    }

    public GameObject GetEnemyBullet()
    {
        return PoolManager.Instance.GetEnemyBulletObject();
    }

    public void PutEnemyBullet(GameObject gameObject)
    {
        PoolManager.Instance.PutEnemyBulletObject(gameObject);
    }

    public GameObject GetPlayerBullet()
    {
        return PoolManager.Instance.GetPlayerBulletObject();
    }

    public void PutPlayerBullet(GameObject gameObject)
    {
        PoolManager.Instance.PutPlayerBulletObject(gameObject);
    }

    public GameObject GetPlayerSpreadBullet()
    {
        return PoolManager.Instance.GetPlayerSpreadBulletObject();
    }

    public void PutPlayerSpreadBullet(GameObject gameObject)
    {
        PoolManager.Instance.PutPlayerSpreadBulletObject(gameObject);
    }

    public GameObject GetPlayerMissile(PlayerType type)
    {
        return PoolManager.Instance.GetPlayerMissileObject(type);
    }

    public void PutPlayerMissile(GameObject gameObject, PlayerType type)
    {
        PoolManager.Instance.PutPlayerMissileObject(gameObject, type);
    }
}
