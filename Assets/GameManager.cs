using UnityEngine;

public class GameManager: MonoBehaviour
{
	public static int punti;
	public static PopinoController pino;
	public InGameManager _IGM;
	private static bool inPausa = false;

	private void Start()
	{
		punti = 0;
	}

	private void Update()
	{
		if (!eInPausa())
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

	public static bool eInPausa()
	{
		return inPausa;
	}
	public static void pausa()
	{
		inPausa = true;
	}
	public static void play()
	{
		inPausa = false;
	}
}
