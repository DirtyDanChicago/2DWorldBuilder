using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed = 10f;

    private bool facingRight = true;
    private Rigidbody2D myRigidBody;

    Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");
        myRigidBody = GetComponent<Rigidbody2D>();

        anim.SetFloat("speed", Mathf.Abs(move));

        myRigidBody.velocity = new Vector2(move * maxSpeed, myRigidBody.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
	}

    //Flips the character for left and right animation.
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
