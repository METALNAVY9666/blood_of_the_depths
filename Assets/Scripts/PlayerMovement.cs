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
		horizontal = Input.GetAxisRaw("horizontal");

        }
	private void FixedUpdate()
	{
		rb.velocity = new 
	}
}
