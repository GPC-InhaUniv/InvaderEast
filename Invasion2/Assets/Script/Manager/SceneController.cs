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
    

}

public class SceneController : Singleton<SceneController> {

    protected SceneController() { }

    public void ChangeScene(SceneState state)
    {
        switch (state)
        {
            case SceneState.Title:
                break;
            case SceneState.CharacterSelect:
                break;
            case SceneState.Store:
                break;
            case SceneState.Battle:
                break;
            default:
                break;
        }
    }
}
