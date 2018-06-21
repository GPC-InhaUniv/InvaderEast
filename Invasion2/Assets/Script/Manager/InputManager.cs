using UnityEngine;


/// <summary>
/// 담당자 : 김정수
/// UI가 알아야하는 정보, UI가 전달하는 정보를 중재자를 통해 연결한다.
/// 일종의 UI들과 연결된 중재자와 비슷한 수준
/// 다른 Manager들의 연결을 끊고 오직 중재자와 대화하기때문에 간단하지만 많은 양의 메소드들이 필요하다.
/// delegate를 통해 UI와 연결되는부분을 처리한다면 양을 줄일 수 있을것 같다.
/// </summary>
/// 

public delegate void ChangeGold();
public class InputManager : Singleton<InputManager>
{
    private GameMediator gameMediator;
    public ChangeGold DelegateGold;
    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }
    //플레이어 이동 및 공격
    public void PlayerMove(Vector3 direction)
    {
        gameMediator.PlayerMove(direction);
    }
    public void PlayerAttack(bool CheckedAttack)
    {
        gameMediator.PlayerAttack(CheckedAttack);
    }
   
    public void PlayerChange(PlayerType type)
    {
        gameMediator.ChangePlayerType(type);
    }

    //플레이어 정보(파워 및 라이프)
    public int ReadPlayerPower()
    {
        return gameMediator.ReadPlayerPower();
    }
    public int ReadPlayerLife()
    {
        return gameMediator.ReadPlayerLife();
    }
    //게임 데이터 읽기
    public int ReadPlayerGold()
    {
        return gameMediator.ReadPlayerGold();
    }
    public int ReadPlayerMaxScore()
    {
        return gameMediator.ReadPlayerMaxScore();
    }
    public int ReadCurrentScore()
    {
        return gameMediator.ReadCurrentScore();
    }
    
    //아이템 거래
    public void BuyItem(ItemType item, int SalePrice)
    {
        gameMediator.ChangeGold(-SalePrice);
        DelegateGold();
        gameMediator.BuyItem(item);
    }
    public void SellItem(ItemType item, int SalePrice)
    {
        gameMediator.ChangeGold(+SalePrice);
        DelegateGold();
        gameMediator.SellItem(item);
    }

    //씬 변경
    public void ChangeScene(SceneState state)
    {
        gameMediator.ChangeScene(state);
    }

}
