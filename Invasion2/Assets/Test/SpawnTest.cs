using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour {

    public GameObject Enemy;
	public void Spawn()
    {
        StageManager.Instance.SetStage();
        StageManager.Instance.NextStage();
        //StageManager.Instance.test();
        
    }
}
