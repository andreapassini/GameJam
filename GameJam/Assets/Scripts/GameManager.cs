using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager: MonoBehaviour
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

	public static void PlayLvlStringente()
    {
		// Load scene
		SceneManager.LoadScene("LivelloStringente");
	}

	public static void PlayLvlFinale()
    {
		SceneManager.LoadScene("Final");
	}

	public static void PlayLvlMainMenu()
    {
		SceneManager.LoadScene("MainMenu");
	}

}
