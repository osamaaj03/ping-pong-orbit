using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBall : MonoBehaviour
{
	public Transform ball, ballContainer;
	public float holdingRange;

	private CircleCollider2D collider;
	private Rigidbody2D rb;
	private bool held = false;
	private Vector2 distance;
	private Vector2 currentSpeed;

	private void Start()
	{
		collider = ball.GetComponent<CircleCollider2D>();
		rb = ball.GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		distance = ball.position - transform.position;
		if (!held && distance.magnitude <= holdingRange && Input.GetKeyDown(KeyCode.Space)) Hold();
		else if (held && Input.GetKeyDown(KeyCode.Space)) Throw();
	}
	private void Hold()
	{
		held = true;
		currentSpeed = rb.velocity;
		rb.velocity = Vector2.zero;

		ball.transform.SetParent(ballContainer);
		ball.transform.position = ballContainer.transform.position;

		rb.isKinematic = true;
		collider.isTrigger = true;
		Debug.Log("held");
	}
	private void Throw()
	{
		held = false;

		ball.transform.SetParent(null);

		rb.isKinematic = false;
		collider.isTrigger = false;

		rb.velocity = currentSpeed;
	}
}
