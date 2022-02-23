using UnityEngine;

public class BedTrigger : MonoBehaviour
{

	[SerializeField] LayerMask player;

	private void Start()
	{
		//Physics2D.IgnoreLayerCollision(13, 7, true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameManager.PlayMainScene();
	}
}
