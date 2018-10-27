using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{

    public float maxSpeed;
    public bool facingRight = true;
    private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");
        myRigidBody = GetComponent<Rigidbody2D>();

        myRigidBody.velocity = new Vector2(move * maxSpeed, myRigidBody.velocity.y);
	}
}
