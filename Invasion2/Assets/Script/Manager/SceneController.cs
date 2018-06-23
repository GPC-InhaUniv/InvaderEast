using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 담당자 : 김정수
/// 
/// 전달받은 SceneState에따라 Scene 변경처리.
/// SceneManager라는 이름을 사용하고 싶었으나 SceneManager는 예약어이기때문에 사용할 수 없다.
/// </summary>
public enum SceneState
{
    Title,
    CharacterSelect,
    Store,
    Battle,
    End,

}
public class SceneController : Singleton<SceneController> {

    protected SceneController() { }
    public void ChangeScene(SceneState state)
    {
        switch (state)
        {
            case SceneState.Title:
                SceneManager.LoadScene(0);
                break;
            case SceneState.CharacterSelect:
                SceneManager.LoadScene(1);
                break;
            case SceneState.Store:
                SceneManager.LoadScene(2);
                break;
            case SceneState.Battle:
                SceneManager.LoadScene(3);
                break;
            case SceneState.End:
                Application.Quit();
                break;
            default:
                break;
        }
    }
}
