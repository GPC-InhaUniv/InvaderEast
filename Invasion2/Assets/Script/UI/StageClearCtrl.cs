using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 작성자 : 최대원
/// 스테이지 클리어 시 나타나는 패널의 컨트롤러
/// </summary>
public class StageClearCtrl : MonoBehaviour {

    [SerializeField]
    Text scoreText;
    [SerializeField]
    int addScore = 7;

    int currentScore;
    int maxScore;

    public void OnClickReturnToTitle()
    {
        Time.timeScale = 1;
        InputManager.Instance.ChangeScene(SceneState.Title);
    }

    public void OnClickRestart()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        StageManager.Instance.restart();
        StageManager.Instance.NextStage();
    }

    private void OnEnable()
    {
        maxScore = InputManager.Instance.ReadCurrentScore();
    }

    private void Update()
    {
        if (currentScore < maxScore)
        {
            currentScore += addScore;
        }
        else if (currentScore > maxScore)
        {
            currentScore = maxScore;
        }
    }
}
