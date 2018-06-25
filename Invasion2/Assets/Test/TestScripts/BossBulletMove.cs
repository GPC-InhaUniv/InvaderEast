using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletMove : MonoBehaviour {

    public float speed;
    Rigidbody rigidbodyComponent;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        rigidbodyComponent.velocity = transform.forward * speed;

    }
  
}
