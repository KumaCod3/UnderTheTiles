using UnityEngine;

public class GameManager: MonoBehaviour
{
	public static int punti;
	public static PopinoController pino;

	private void Start()
	{
		punti = 0;
	}

	private void Update()
	{
		if (punti < 0)
		{
			punti = 0;
		}
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Vector3 cor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			int xx = Mathf.RoundToInt(cor.x);
			int yy = Mathf.RoundToInt(cor.y);
			if (BoardManager.check(yy, xx))
			{
				pino.moveTo(yy, xx);
			}
		}
	}


	// fai click mouse su board!
	/*
	 * arrotonda a x,y
	 * 
	 * poi:
	   if (BoardManager.check(posX - 1, posY))
		{
			PopinoController.moveTo(posX - 1, posY);
		}

	*/


}
