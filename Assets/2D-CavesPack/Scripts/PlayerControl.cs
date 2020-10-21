﻿using UnityEngine;
using System.Collections;

/*This class is a revised version of PlayerControl from Unity's 2D project example.
 For use with a sprite animation*/

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.


	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public float idleSpeed = 0.001f;
	public float jumpForce = 20f;			// Amount of force added when the player jumps.
	public GameObject sprite;				// Reference to the sprite animation object
	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.

	public bool showGuiControls = true;
	private bool leftOn = false;
	private bool rightOn = false;
	private float speed = 1f;
	private Animator animator;				// Reference to the sprite's animator component.

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		animator = sprite.GetComponent<Animator>();
	}

	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
		{
			Debug.Log ("jumped");
			jump = true;
		}
	}


	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		if(leftOn)
			h = -speed;
		if(rightOn)
			h = speed;

		if(h != 0)
			GetComponent<Rigidbody2D>().velocity = new Vector2(h * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		if(GetComponent<Rigidbody2D>().velocity.x <= idleSpeed && GetComponent<Rigidbody2D>().velocity.x >= -idleSpeed && GetComponent<Rigidbody2D>().velocity.y <= 0 && grounded)
		{
			animator.SetBool("Walking", false);
			animator.SetBool("Jumping", false);
		}
		else if(grounded && GetComponent<Rigidbody2D>().velocity.y <= idleSpeed)
		{
			animator.SetBool("Walking", true);
			animator.SetBool("Jumping", false);
		}
			
		// If the player should jump...
		if(jump)
		{
			animator.SetBool("Jumping", true);
			animator.SetBool("Walking", false);

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

	void OnGUI()
	{
		if(showGuiControls)
		{
			if(GUI.RepeatButton (new Rect (0,Screen.height - 50,100,50), "Left"))
			{
				leftOn = true;
				rightOn = false;
			}
			else
				leftOn = false;
			if(GUI.RepeatButton (new Rect (100,Screen.height - 50,100,50), "Right"))
			{
				leftOn = false;
				rightOn = true;
			}
			else
				rightOn = false;
			if(GUI.Button (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Jump"))
			{
				jump = true;
			}
		}
	}

}