using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] float speed = 100f;
	[SerializeField] float jumpForce;

	[SerializeField] float fallMultiplier = 2.5f;
	[SerializeField] float lowJumpMultiplier = 2f;

	private float _input;
	private bool _isJumping, _isGrounded;

	private Rigidbody2D _rb;

	[SerializeField] LayerMask whatIsGround;
	[SerializeField] Transform groundCheck;

	[SerializeField] float jumpBuffer = 1f;

	private float _lastTimeJumpPressed = -100f;

	const float groundedRadius = .1f;

	public bool facingRight = true;

	public LevelSwapper LevelSwapper;
	private Animator _animator;

	public AudioSource AudioSourceFootStep;

	public float SecondStepTime;
	private float _firstStepTime;
	private bool _stopedWalking = true;
	private bool _falling = false;

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

			// Footstep sound
			// Play when walking and some time passed
			if (_isGrounded && ((Time.time - _firstStepTime > SecondStepTime) || _stopedWalking))
            {
				_stopedWalking = false;
				AudioSourceFootStep.Play();
				_firstStepTime = Time.time;
			}

        } else
        {
			_animator.SetBool("isRunning", false);
			_stopedWalking = true;
		}

		if (!_isGrounded)
			_falling = true;
        else if(_falling)
        {
			// Play sound when landed
			if (_isGrounded)
				AudioSourceFootStep.Play();
			_falling = false;
		}
			
	}

	private void FixedUpdate()
	{
		_rb.velocity = new Vector2(_input * speed, _rb.velocity.y);

		//Controllo che il Player non sia in aria
		_isGrounded = false;
		_isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);

		Jump();
		//BetterJump();

		Flip();
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck.position, groundedRadius);
	}

	private void Flip()
	{
		if (_input > 0 && !facingRight) {
			transform.localEulerAngles = new Vector3(0, transform.eulerAngles.y + 180f, transform.eulerAngles.z);
			facingRight = !facingRight;
		} else if (_input < 0 && facingRight) {
			transform.localEulerAngles = new Vector3(0, transform.eulerAngles.y + 180f, transform.eulerAngles.z);
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
			// Stop 
			_rb.velocity = new Vector2(0f, 0f);

			//_rb.AddForce(transform.InverseTransformPoint(Vector2.up * jumpForce) , ForceMode2D.Impulse);
			_rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

			_isJumping = false;
			_lastTimeJumpPressed = 0f;

			LevelSwapper.SwapTile();

			_animator.SetBool("isJumping", true);

			return;
		}

        if (HasBufferdJump())
        {
			// Stop 
			_rb.velocity = new Vector2 (0f, 0f);

			//_rb.AddForce(transform.InverseTransformPoint(Vector2.up * jumpForce), ForceMode2D.Impulse);
			_rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

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

	public void BetterJump()
	{
		if(_rb.velocity.y < 0) 
		{
			_rb.velocity += new Vector2(0, _rb.velocity.y) * Physics2D.gravity.y * (fallMultiplier - 1);
		} 
		else if(_rb.velocity.y > 0 && !Input.GetMouseButton(0)) 
		{
			_rb.velocity += new Vector2(0, _rb.velocity.y) * Physics2D.gravity.y * (lowJumpMultiplier - 1);
		}
	}
}
