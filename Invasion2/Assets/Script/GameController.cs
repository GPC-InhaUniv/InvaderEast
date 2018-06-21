using UnityEngine;

/// <summary>
/// 담장자 : 김정수
/// 
/// 메인 게임 시작시 필요한 정보들의 관리
/// Ex) 플레이어 시작 위치, 스테이지 시작, 배경관리 등
/// </summary>

public class GameController : MonoBehaviour {

    GameMediator gameMediator;
    GameObject player;
    PoolManager poolnstance;
    // Use this for initialization
    private void Awake()
    {
        poolnstance = PoolManager.Instance;
        StageManager.Instance.SetStage();
    }
    void Start () {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        player = GameObject.FindGameObjectWithTag("Player");

        //PoolManager.Instance.SetQueue();
        
        StageManager.Instance.NextStage();

    }
	
	
}
