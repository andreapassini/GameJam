using UnityEngine;
using System.Collections;
using System;

public class BedTrigger : MonoBehaviour
{
	public Transform LevelLoarder;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		LevelLoarder.GetComponent<GameManager>().PlayMainScene();
	}
}
