using UnityEngine;

public class GameManager: MonoBehaviour
{
	public static int punti;
	public static PopinoController pino;
	public InGameManager _IGM;
	public static bool pausa = true;

	private void Start()
	{
		punti = 0;
	}

	private void Update()
	{
		if (!pausa)
		{

			if (punti < 0)
			{
				punti = 0;
			}

			Vector3 cor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			int xx = Mathf.RoundToInt(cor.x);
			int yy = Mathf.RoundToInt(cor.y);
			if (BoardManager.checkLim(yy, xx) && BoardManager.sopraCarta(yy, xx).GetComponent<baseCarta>())
			{
				string tip = BoardManager.sopraCarta(yy, xx).GetComponent<baseCarta>().tipo;
				string nom = BoardManager.sopraCarta(yy, xx).GetComponent<baseCarta>().nome;
				string desc = BoardManager.sopraCarta(yy, xx).GetComponent<baseCarta>().descrizione;
				_IGM.setDesc(tip, nom, desc);
			}
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (BoardManager.check(yy, xx))
				{
					pino.moveTo(yy, xx);
				}
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
