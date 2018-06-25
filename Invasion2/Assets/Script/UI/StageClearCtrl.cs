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
    Text getScoreText;
    [SerializeField]
    Text maxScoreText;

    public void OnClickReturnToTitle()
    {
        GameMediator.Instance.GameOver();
        Time.timeScale = 1;
        GameMediator.Instance.ChangeScene(SceneState.CharacterSelect);
    }

    public void OnClickRestart()
    {
        GameMediator.Instance.GameOver();
        if (StageManager.Instance.restart != null)
            StageManager.Instance.restart();
        StageManager.Instance.NextStage();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        getScoreText.text = GameMediator.Instance.ReadCurrentScore().ToString();
        maxScoreText.text = GameMediator.Instance.ReadPlayerMaxScore().ToString();
    }
}
