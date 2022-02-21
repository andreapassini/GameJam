using UnityEngine;

public class LevelSwapper: MonoBehaviour
{
	[SerializeField] private GameObject tileRed;
	[SerializeField] private GameObject tileBlue;

	private bool blueActive;

	private void Start()
	{
		tileRed.SetActive(true);
		blueActive = false;
	}

	// Swap from a level to another
	public void SwapTile()
	{
		if (blueActive)
		{
			SwapRed();
			return;
		}

		SwapBlue();
	}

	public void SwapBlue()
	{
		tileRed.SetActive(false);
		tileBlue.SetActive(true);

		blueActive = false;
	}

	public void SwapRed()
	{
		tileBlue.SetActive(false);
		tileRed.SetActive(true);

		blueActive = true;
	}
}
