using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour {

	public int moveSpeed = 6;
	public float spacing = 0.5f;

	private bool canMove;

	public Transform ballTransform;
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (Mathf.Abs(ballTransform.position.y - transform.localPosition.y) > spacing)
		{
				rb.velocity = (ballTransform.position.y > transform.position.y) ?
				Vector2.up * moveSpeed :
				-Vector2.up * moveSpeed;
		}
		else
		{
			rb.velocity = Vector2.zero;
		}
	}
}
