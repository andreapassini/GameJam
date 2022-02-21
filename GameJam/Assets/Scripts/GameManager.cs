using UnityEngine;
using UnityEngine.SceneManagement;

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
		SceneManager.LoadScene("Main");

		// Add Transition
	}
}
