using UnityEngine;

public class GravitySwitch: MonoBehaviour
{
	public Vector3 GravitySwitchDirection = new Vector3(-1.0f, 0.0f, 0.0f);
	public bool rotateCamera = false;

	[SerializeField] Transform environment;

	private Vector3 _standardGravity;

	private void Start()
	{
		_standardGravity = new Vector3(0, -1.0f, 0);
	}

	// Start is called before the first frame update
	public void ResetGravity()
	{
		Physics2D.gravity = _standardGravity;
	}

	public void SwitchGravity()
	{
		// Non serve cambiare la gravità, basta far ruotare tutto il resto
		// Così rimangono costanti i movimenti ed il salto

		// Rotate the player
		// Ruoto il player in modo che:
		//      - localUp (il suo asse delle Y) segua la direzione di gravityUp
		Quaternion targetRotation = Quaternion.FromToRotation(environment.up, GravitySwitchDirection) * environment.rotation;
		environment.rotation = targetRotation;
		//_player.rotation = Quaternion.RotateTowards(_player.rotation, targetRotation, 50f * Time.deltaTime);

		// Potrei ruotare anche la Camera
	}
}
