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

	[SerializeField] float jumpBuffer = 1f;

	private float _lastTimeJumpPressed = -100f;

	const float groundedRadius = .2f;

	public LevelSwapper LevelSwapper;

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

		if (Input.GetButtonDown("Jump")) 
		{
			if(!_isGrounded)
				_lastTimeJumpPressed = Time.time;

			if(_isGrounded)
				_isJumping = true;
        }
	}

	private void FixedUpdate()
	{
		_rb.velocity = new Vector2(_input * speed, _rb.velocity.y);

		//Controllo che il Player non sia in aria
		_isGrounded = false;
		_isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

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
		if (!_isGrounded)
		{
			return;
		}

		if (_isJumping)
		{
			Debug.Log("Jump");

			_rb.AddForce(transform.up * (jumpForce), ForceMode2D.Impulse);
			_isJumping = false;
			_lastTimeJumpPressed = 0f;

			LevelSwapper.SwapTile();
		}

        if (HasBufferdJump())
        {
			Debug.Log("Buffer Jump");

			// Add a bit more force to contrast the difference betweeen collider and groundCheck
			_rb.AddForce(transform.up * (jumpForce) * 2f, ForceMode2D.Impulse);
			_isJumping = false;
			_lastTimeJumpPressed = 0f;

			LevelSwapper.SwapTile();
		}

	}

	private bool HasBufferdJump()
    {
		if (_lastTimeJumpPressed + jumpBuffer > Time.time)
        {
			return true;
		}		

		return false;
    }
}
