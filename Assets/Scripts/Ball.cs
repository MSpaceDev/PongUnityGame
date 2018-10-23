using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float launchSpeed;
	public int maxSpeed = 30;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		transform.localPosition = (GameManager.instance.lastWinner == 1) ?
			new Vector3(1.5f, transform.position.y, 10) :
			new Vector3(-1.5f, transform.position.y, 10);
		
		StartCoroutine(MoveBall());
	}

	void Update()
	{
		if (rb.velocity.magnitude > maxSpeed)
		{
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
	}

	private IEnumerator MoveBall()
	{
		yield return new WaitForSeconds(1);

		// Make ball go left or right
		Vector2 dir = (GameManager.instance.lastWinner == 1) ? Vector2.right : Vector2.left;
		rb.velocity = dir * launchSpeed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		AudioManager.instance.Play(0);

		BoxCollider2D collider = (BoxCollider2D) collision.collider;

		if (collider == null)
			return;
		else if (collider.attachedRigidbody == null)
			return;

		float magnitude = rb.velocity.magnitude;

		if (collider.attachedRigidbody.name == "Player1")
		{
			rb.velocity = (collider.name == "TriggerLeft") ?
				new Vector2(1, 0.7f).normalized * magnitude :
				new Vector2(1, -0.7f).normalized * magnitude;
		}
		else if (collider.attachedRigidbody.name == "Player2")
		{
			rb.velocity = (collider.name == "TriggerLeft") ?
					new Vector2(-1, 0.7f).normalized * magnitude :
					new Vector2(-1, -0.7f).normalized * magnitude;
		}
	}
}
