using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody2D playerRigidBody2D;

	private Animator animator;

	private GameObject playerSprite;

	private float movePlayerVector;

	private bool facingRight;

	public float speed = 4.0f;

	void Awake() {
		playerRigidBody2D = (Rigidbody2D)GetComponent (typeof(Rigidbody2D));
		playerSprite = transform.Find ("PlayerSprite").gameObject;
		animator = (Animator)playerSprite.GetComponent (typeof(Animator));
	
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movePlayerVector = Input.GetAxis ("Horizontal");

		animator.SetFloat ("speed", Mathf.Abs (movePlayerVector));

		playerRigidBody2D.velocity = new Vector2 (movePlayerVector * speed, playerRigidBody2D.velocity.y);

		if (movePlayerVector > 0 && !facingRight) {
			Flip();
		}
		else if(movePlayerVector < 0 && facingRight) {
			Flip();
		}
	}

	void Flip() 
	{
		facingRight = !facingRight;
		Vector3 theScale = playerSprite.transform.localScale;
		theScale.x *= -1;
		playerSprite.transform.localScale = theScale;
	}

}
