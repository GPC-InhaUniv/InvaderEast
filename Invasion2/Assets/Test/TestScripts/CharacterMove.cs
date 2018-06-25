using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    Rigidbody rigidBody;
    float moveSpeed;

    float MoveToHorizontal;
    float MoveToVertical;

    Vector3 characterMove;



	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        moveSpeed = 4.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveToHorizontal = Input.GetAxis("Horizontal");
        MoveToVertical = Input.GetAxis("Vertical");

        characterMove = new Vector3(MoveToHorizontal, 0, MoveToVertical);

        rigidBody.velocity = characterMove * moveSpeed;
	}
}
