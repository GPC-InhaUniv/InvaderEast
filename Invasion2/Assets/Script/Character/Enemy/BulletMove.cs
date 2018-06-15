using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 담당자 : 김지섭

// 적 총알 이동 코드입니다

public class BulletMove : MonoBehaviour {

    Rigidbody rigidbody;

    private float speed = 20;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
        //speed = 20.0f;
        //transform.rotation = new Quaternion(0, 180.0f, 0, 0);
    }

    void Update()
    {
        //transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
