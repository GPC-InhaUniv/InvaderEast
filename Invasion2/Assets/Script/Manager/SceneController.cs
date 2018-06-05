using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.SceneManagement;
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
    GameMediator gameMediator;
    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }
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
                break;
            default:
                break;
        }
    }
}
