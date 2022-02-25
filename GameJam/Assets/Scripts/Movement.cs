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

	const float groundedRadius = .01f;

	public bool facingRight = true;

	private LevelSwapper LevelSwapper;

	private Animator _animator;

	private void Awake()
	{
		_rb = gameObject.GetComponent<Rigidbody2D>();
		_isJumping = false;
		_isGrounded = false;

		_animator = GetComponent<Animator>();
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

		// Trigger the animation Run
		if(_input != 0)
        {
			_animator.SetBool("isRunning", true);
        } else
        {
			_animator.SetBool("isRunning", false);
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
		if (_input > 0 && !facingRight) {
			transform.localEulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
			facingRight = !facingRight;
		} else if (_input < 0 && facingRight) {
			transform.localEulerAngles = new Vector3(0, 180f, transform.eulerAngles.z);
			facingRight = !facingRight;
		}
	}

	private void Jump()
	{
		if (!_isGrounded)
		{
			_animator.SetBool("isJumping", false);

			return;
		}

		if (_isJumping)
		{
			_rb.AddForce(transform.InverseTransformPoint(Vector2.up * jumpForce) , ForceMode2D.Impulse);

			_isJumping = false;
			_lastTimeJumpPressed = 0f;

			LevelSwapper.SwapTile();

			_animator.SetBool("isJumping", true);

			return;
		}

        if (HasBufferdJump())
        {
			// Add a bit more force to contrast the difference betweeen collider and groundCheck
			_rb.AddForce(transform.InverseTransformPoint(transform.up * jumpForce * 2f), ForceMode2D.Impulse);
			_isJumping = false;
			_lastTimeJumpPressed = 0f;

			LevelSwapper.SwapTile();

			_animator.SetBool("isJumping", true);
		}

		//_animator.SetBool("isJumping", false);

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
