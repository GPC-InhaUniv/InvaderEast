using UnityEngine;

public class StoreUI : MonoBehaviour {

    public void OnExitButton()
    {
        InputManager.Instance.ChangeScene(SceneState.CharacterSelect);
    }
}
