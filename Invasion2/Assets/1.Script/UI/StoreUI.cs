using UnityEngine;
/// <summary>
/// 담당자 : 김정수
/// 상점에서 나가기 위한 임시 스크립트
/// </summary>
public class StoreUI : MonoBehaviour {

    public void OnExitButton()
    {
        GameMediator.Instance.ChangeScene(SceneState.CharacterSelect);
    }
}
