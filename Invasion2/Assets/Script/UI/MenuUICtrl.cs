using UnityEngine;
using UnityEngine.UI;
public class MenuUICtrl : MonoBehaviour
{
    [SerializeField]
    GameObject MenuPanel;

    public void OnClickRestartButton()
    {
        Time.timeScale = 1;
        //InputManager.Instance.ChangeScene(SceneState.Battle);
        GameMediator.Instance.GameOver();
        MenuPanel.SetActive(false);
        if(StageManager.Instance.restart!=null)
        StageManager.Instance.restart();
        StageManager.Instance.NextStage();
    }

    public void OnClickReturnToTitleButton()
    {
        Time.timeScale = 1;
        GameMediator.Instance.GameOver();
        PoolManager.Instance.ClearQueue();
        StageManager.Instance.SetRestart();
        GameMediator.Instance.ChangeScene(SceneState.CharacterSelect);
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
    }    
}
