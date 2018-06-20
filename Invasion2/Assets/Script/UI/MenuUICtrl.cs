
using UnityEngine;

public class MenuUICtrl : MonoBehaviour
{

    public void OnClickReturnTitle()
    {
        Debug.Log("타이틀 화면 클릭");
        InputManager.Instance.ChangeScene(SceneState.Title);
      // SceneManager.LoadScene("Title");
    }

    public void OnClickRestartButton()
    {
        Debug.Log("재시작 버튼 클릭");
        InputManager.Instance.ChangeScene(SceneState.Battle);
      // SceneManager.LoadScene("MainGame");
    }

    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        Debug.Log("일시정지 버튼 클릭");
    }


}
