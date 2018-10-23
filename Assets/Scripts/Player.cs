using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int moveSpeed = 600;

	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		float moveY;

		if (gameObject.tag == "Player1")
			moveY = Input.GetAxisRaw("Player1") * moveSpeed * Time.deltaTime;
		else
			moveY = Input.GetAxisRaw("Player2") * moveSpeed * Time.deltaTime;

		rb.velocity = new Vector2(0, moveY);
	}
}
