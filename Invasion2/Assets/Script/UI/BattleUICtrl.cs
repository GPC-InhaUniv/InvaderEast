using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUICtrl : MonoBehaviour
{/// <summary>
/// 배틀 UI  캐릭터 선택시 해당 캐릭터의 
/// 이미지를 가져와서 lifetext 옆에 구현 하고 싶습니다!!
/// </summary>
    InputManager inputManager;
    public Text lifeText;
    public Image powerGauge;
    public Text score;
    //public Image characters;
    
    private bool isPaused;

void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    void ChangeLife()
    {
        lifeText.text = inputManager.ReadPlayerLife().ToString();
    }
    void ChangePowerGauge()
    {
        powerGauge.fillAmount = inputManager.ReadPlayerPower();
    }
    void ChangeScore()
    {
        score.text = inputManager.ReadPlayerMaxScore().ToString();
    }
    public void OnPauseClick()
    {                                                                                                        
        isPaused = !isPaused;
        Time.timeScale = (isPaused) ? 0.0f : 1.0f;
       
    }
    //void ChangeCharacters()
    //{
    //    PlayerType.Sin.
    //}
}
