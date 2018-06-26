using UnityEngine;

/// <summary>
/// 담장자 : 김정수
/// 
/// 메인 게임 시작시 필요한 정보들의 관리
/// Ex) 플레이어 시작 위치, 스테이지 시작, 배경관리 등
/// </summary>

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject GameOverPanel;
    // Use this for initialization
    private void Awake()
    {
        PoolManager.Instance.SetQueue();
        StageManager.Instance.SetStage();
        
    }
    void Start()
    {
        StageManager.Instance.NextStage();
        GameMediator.Instance.changeLife += new GameMediator.DoChangeLifeDelegate(EndGame); 
    }

    public void EndGame()
    {
        
        if(GameMediator.Instance.ReadPlayerLife() <=0)
        {
            Time.timeScale = 0; 
            GameOverPanel.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        GameMediator.Instance.changeLife -= new GameMediator.DoChangeLifeDelegate(EndGame);
    }
}
