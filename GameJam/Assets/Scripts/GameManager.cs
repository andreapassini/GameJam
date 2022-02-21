using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class GameManager
{
	// I could use a FSM

	public static void PlayStartScene()
	{
		// Load scene
		SceneManager.LoadScene("Start");

		// Add Transition
	}

	public static void PlayMainScene()
	{
		// Load scene
		Debug.Log("Called Play Scene Main");
		SceneManager.LoadScene("Main");

		// Add Transition
	}


}
