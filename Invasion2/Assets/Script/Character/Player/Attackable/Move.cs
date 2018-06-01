using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour {

    public float speed;
    Rigidbody rigidbody;
    
    
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
	}
	
	
	void Update ()
    {
		
	}
}
