using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// I could use an FSM

	public void PlayStartScene()
	{
		// Load scene
		SceneManager.LoadScene("Start");

		// Add Transition
	}

	public void PlayMainScene()
	{
		// Load scene
		SceneManager.LoadScene("Main");

		// Add Transition
	}
}
