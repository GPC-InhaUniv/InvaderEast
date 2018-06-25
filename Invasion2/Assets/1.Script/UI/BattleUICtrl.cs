using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUICtrl : MonoBehaviour
{/// <summary>
/// 배틀 UI  캐릭터 선택시 해당 캐릭터의 
/// 이미지를 가져와서 lifetext 옆에 구현 하고 싶습니다!! 
/// </summary>
    
        //public -> private 변경할 것.
    public Text lifeText;
    public Image powerGauge;
    public Text score;
    [SerializeField]
    private Sprite [] characters;
    [SerializeField]
    GameObject MenuPanel;
    [SerializeField]
    Image characterImage;
void Start()
    {
        ChangeLife();
        ChangePowerGauge();
        ChangeCharacterImage(GameMediator.Instance.ReadPlayerType());
        GameMediator.Instance.CheckedChangeScore += new GameMediator.DoChangeScoreDelegate(ChangeScore);
        GameMediator.Instance.changePower += new GameMediator.DoChangePowerDelegate(ChangePowerGauge);
        GameMediator.Instance.changeLife += new GameMediator.DoChangeLifeDelegate(ChangeLife);
        
    }

    void ChangeCharacterImage(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.Deung:
                characterImage.sprite = characters[2];
                break;
            case PlayerType.Sin:
                characterImage.sprite = characters[0];
                break;
            case PlayerType.Ho:
                characterImage.sprite = characters[1];
                break;
        }
    }

    void ChangeLife()
    {
        lifeText.text = "LIFE X " + GameMediator.Instance.ReadPlayerLife().ToString();
    }
    void ChangePowerGauge()
    {
      
        powerGauge.fillAmount = GameMediator.Instance.ReadPlayerPower() * 0.033f;
    }
    void ChangeScore()
    {
      
        score.text = "SCORE : " + GameMediator.Instance.ReadCurrentScore().ToString();
    }
    public void OnPauseClick()
    {

        Time.timeScale = 0;

        MenuPanel.SetActive(true);
       
    }
    private void OnDestroy()
    {
        GameMediator.Instance.CheckedChangeScore -= new GameMediator.DoChangeScoreDelegate(ChangeScore);
        GameMediator.Instance.changePower -= new GameMediator.DoChangePowerDelegate(ChangePowerGauge);
        GameMediator.Instance.changeLife -= new GameMediator.DoChangeLifeDelegate(ChangeLife);
    }
}
