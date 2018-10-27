using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float jumpForce = 700f;

    public bool grounded = false;
    public float groundRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private bool facingRight = true;
    private Rigidbody2D myRigidBody;


    Animator anim;

	// Use this for initialization
	private void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void FixedUpdate ()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("ground", grounded);

        anim.SetFloat("vspeed", myRigidBody.velocity.y);

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

    private void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("ground", false);
            myRigidBody.AddForce(new Vector2(0, jumpForce));
        }
    }

    //Flips the character for left and right animation.
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
