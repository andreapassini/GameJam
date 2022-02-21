using UnityEngine;

public class BedTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameManager.PlayMainScene();
	}
}
