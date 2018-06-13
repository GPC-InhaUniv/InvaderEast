using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameMainData : MonoBehaviour {
    [HideInInspector]
    public int Gold;
    [HideInInspector]
    public int MaxScore;
    [HideInInspector]
    public string filePath;
}
