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
        MenuPanel.SetActive(false);
        StageManager.Instance.restart();
        StageManager.Instance.NextStage();
    }

    public void OnClickReturnToTitleButton()
    {
        Time.timeScale = 1;
        PoolManager.Instance.ClearQueue();
        StageManager.Instance.SetRestart();
        InputManager.Instance.ChangeScene(SceneState.CharacterSelect);
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
    }    
}
