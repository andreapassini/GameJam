using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] float speed = 100f;
	[SerializeField] float jumpForce;
	private float _input;
	private bool _isJumping, _isGrounded;

	private Rigidbody2D _rb;

	[SerializeField] LayerMask whatIsGround;
	[SerializeField] Transform groundCheck;
	const float groundedRadius = .2f;

	[SerializeField] GameObject tileRed;
	[SerializeField] GameObject tileBlue;

	private void Awake()
	{
		_rb = gameObject.GetComponent<Rigidbody2D>();
		_isJumping = false;
		_isGrounded = false;
	}

	private void Update()
	{
		_input = Input.GetAxisRaw("Horizontal");
		//Potrei anche usare un vettore normalizzato

		if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) {
			_isJumping = true;
		}
	}

	private void FixedUpdate()
	{
		_rb.velocity = new Vector2(_input * speed, _rb.velocity.y);

		Jump();

		Flip();
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck.position, groundedRadius);
	}

	private void Flip()
	{
		if (_input > 0) {
			transform.eulerAngles = new Vector3(0, 0, 0);
		} else if (_input < 0) {
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}

	private void Jump()
	{
		//Controllo che il Player non sia in aria
		_isGrounded = false;
		_isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

		if (!_isGrounded) {
			return;
		}

		if (_isJumping) {
			SwapTile();

			//rb.velocity = Vector2.up * jumpForce;
			_rb.AddForce(transform.up * (jumpForce), ForceMode2D.Impulse);
			_isJumping = false;
		}
	}

	// Swap from a level to another
	private void SwapTile()
	{
		if (tileBlue.activeSelf) {
			tileBlue.SetActive(false);
			tileRed.SetActive(true);
			return;
		}

		tileRed.SetActive(false);
		tileBlue.SetActive(true);
	}
}
