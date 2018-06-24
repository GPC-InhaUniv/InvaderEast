using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUICtrl : MonoBehaviour
{/// <summary>
/// 배틀 UI  캐릭터 선택시 해당 캐릭터의 
/// 이미지를 가져와서 lifetext 옆에 구현 하고 싶습니다!! 
/// </summary>
    
    public Text lifeText;
    public Image powerGauge;
    public Text score;
    public Image [] characters;
    
    private bool isPaused;
    [SerializeField]
    GameObject MenuPanel;

void Start()
    {
        ChangeLife();
        ChangePowerGauge();
        GameMediator.Instance.CheckedChangeScore += new GameMediator.CheckChangeScore(ChangeScore);
        GameMediator.Instance.changePower += new GameMediator.ChangePower(ChangePowerGauge);
        GameMediator.Instance.changeLife += new GameMediator.ChangeLife(ChangeLife);
    }

    void ChangeLife()
    {
        Debug.Log("체력 바 변경");
        lifeText.text = "LIFE X " + GameMediator.Instance.ReadPlayerLife().ToString();
    }
    void ChangePowerGauge()
    {
        powerGauge.fillAmount = GameMediator.Instance.ReadPlayerPower() * 0.01f;
    }
    void ChangeScore()
    {
        score.text = GameMediator.Instance.ReadCurrentScore().ToString();
    }
    public void OnPauseClick()
    {

        Time.timeScale = 0;

        MenuPanel.SetActive(true);
       
    }
    private void OnDestroy()
    {
        GameMediator.Instance.CheckedChangeScore -= new GameMediator.CheckChangeScore(ChangeScore);
        GameMediator.Instance.changePower -= new GameMediator.ChangePower(ChangePowerGauge);
        GameMediator.Instance.changeLife -= new GameMediator.ChangeLife(ChangeLife);
    }
}
