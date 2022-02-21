using UnityEngine;

public class LevelSwapper: MonoBehaviour
{
	[SerializeField] private GameObject tileRed;
	[SerializeField] private GameObject tileBlue;

	private bool _blueActive = false;

	private void Start()
	{
		_blueActive = !tileRed.activeSelf;
	}

	// Swap from a level to another
	public void SwapTile()
	{
		if (_blueActive)
		{
			SwapRed();
			return;
		}

		SwapBlue();
	}

	public void SwapRed()
	{
		tileBlue.SetActive(false);
		tileRed.SetActive(true);

		_blueActive = false;
	}

	public void SwapBlue()
	{
		tileRed.SetActive(false);
		tileBlue.SetActive(true);

		_blueActive = true;
	}
}
