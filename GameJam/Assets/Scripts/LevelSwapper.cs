using UnityEngine;

public class LevelSwapper: MonoBehaviour
{
	[SerializeField] private GameObject tileRed;
	[SerializeField] private GameObject tileBlue;

	// Swap from a level to another
	public void SwapTile()
	{
		if (tileBlue.activeSelf)
		{
			tileBlue.SetActive(false);
			tileRed.SetActive(true);
			return;
		}

		tileRed.SetActive(false);
		tileBlue.SetActive(true);
	}
}
