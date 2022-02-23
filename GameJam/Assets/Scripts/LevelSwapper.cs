using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelSwapper: MonoBehaviour
{
	[SerializeField] private GameObject tileRed;
	[SerializeField] private GameObject tileBlue;

	private bool _blueActive = false;

	private void Start()
	{
		SwapRed();
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
		Physics2D.IgnoreLayerCollision(7, 11, false);
		Physics2D.IgnoreLayerCollision(7, 12, true);

		TilemapRenderer spriteRenderer = tileBlue.GetComponent<TilemapRenderer> ();
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

		spriteRenderer = tileRed.GetComponent<TilemapRenderer> ();
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;

	    



		_blueActive = false;
	}

	public void SwapBlue()
	{
		Physics2D.IgnoreLayerCollision(7, 12, false);
		Physics2D.IgnoreLayerCollision(7, 11, true);

		TilemapRenderer spriteRenderer = tileRed.GetComponent<TilemapRenderer> ();
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

		spriteRenderer = tileBlue.GetComponent<TilemapRenderer> ();
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;

		

		_blueActive = true;
	}

}
