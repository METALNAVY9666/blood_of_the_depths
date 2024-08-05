using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float	horizontal;
	private float	speed;
	private float	jump_power;
	private bool	is_facing_right;
	[SerializeField] private RigidBody2D	rb;
	[SerializeField] private Transform	ground_check;
	[SerializeField] private LayerMask	ground_layer;

	horizontal = 0;
	speed = 8f;
	jump_power = 16f;
	is_facing_right = true;
	void Start()
	{
	}
	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		CheckJump();
		CheckFlip();

        }
	private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); 
	}
	private	bool isGrounded()
	{
		return Physics2D.OverlapCircle(ground_check.position, 0.2f, ground_layer);
	}
	private void CheckFlip()
	{
		if ((is_facing_right && horizontal < 0) || (!is_facing_right && horizontal > 0))
		{
			is_facing_right = !is_facing_right;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}
	private void CheckJump()
	{
		if (isGrounded() && Input.GetButtonDown("Jump"))
		{
			rb.velocity = new Vector2(rb.velocity.x, jump_power);
		}

		if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}
	}
}
