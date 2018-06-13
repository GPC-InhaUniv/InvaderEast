using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 작성자 : 김정수
/// 
/// 오브젝트 파괴 방지를 위한 "임시" 스크립트
/// 
/// </summary>

public class Dontddd : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	
}
