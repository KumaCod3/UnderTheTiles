using System.Collections;
using UnityEngine;
public class PopinoController: MonoBehaviour
{
	public static int posX;
	public static int posY;
	private static int attacco = 1;
	private static int vita = 2;

	public void camVita(int v)
	{
		vita = v;
		gameObject.GetComponent<GestCarta>().cambia1("" + vita);
	}
	public void camAtta(int a)
	{
		attacco = a;
		gameObject.GetComponent<GestCarta>().cambia2("" + attacco);
	}
	public void camPun(int p)
	{
		GameManager.punti = p;
		gameObject.GetComponent<GestCarta>().cambia4("" + GameManager.punti);
	}
	public int getVita()
	{
		return vita;
	}
	public int getAttacco()
	{
		return attacco;
	}

	void Update()
	{
		if (!GameManager.eInPausa())
		{
			if (vita <= 0)
			{
				Debug.Log("GAME OVEEEEER!!!!");
				GameManager.pausa();
				gameObject.GetComponent<GestCarta>().diePop();
			}
		}
	}


	private bool prova(int x, int y)
	{
		bool tr = false;
		if (BoardManager.check(x, y))
		{
			if (!BoardManager.scacchiera[x][y].GetComponent<CartaUscita>())
			{
				if (!BoardManager.scacchiera[x][y].GetComponent<Usata>())
				{
					if (BoardManager.scacchiera[x][y].GetComponent<CartaMostro2>())
					{
						BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
						Destroy(BoardManager.scacchiera[x][y].gameObject);
						BoardManager.scacchiera[x][y] = null;
					}
					tr = true;
				}
				else
				{
					tr = GameManager.punti >= BoardManager.scacchiera[x][y].GetComponent<Usata>().punti;
				}
			}
			else
			{
				tr = BoardManager.scacchiera[x][y].GetComponent<CartaUscita>().punti <= GameManager.punti;
			}
		}
		return tr;
	}


	private bool bloccato(int x, int y)
	{
		return (prova(x - 1, y) || prova(x + 1, y) || prova(x, y - 1) || prova(x, y + 1));
	}
	internal void setXY(int x, int y)
	{
		posX = x;
		posY = y;
		GameManager.pino = this;
	}


	public IEnumerator moveToR(int x, int y)
	{
		if (!BoardManager.scacchiera[x][y].GetComponent<CartaUscita>())
		{
			if (!BoardManager.scacchiera[x][y].GetComponent<Usata>() || GameManager.punti >= BoardManager.scacchiera[x][y].GetComponent<Usata>().punti)
			{
				BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
				GameManager.pausa();

				yield return new WaitForSeconds(.3f);
				pt2(x, y);

			}
			//else if (BoardManager.scacchiera[x][y].GetComponent<Usata>() && GameManager.punti >= BoardManager.scacchiera[x][y].GetComponent<Usata>().punti)
			//{
			//	BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
			//	GameManager.pausa();

			//	yield return new WaitForSeconds(.3f);
			//	pt2(x, y);
			//}
		}
		else if (BoardManager.scacchiera[x][y].GetComponent<CartaUscita>() && BoardManager.scacchiera[x][y].GetComponent<CartaUscita>().punti <= GameManager.punti)
		{
			BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
			BoardManager.scacchiera[posX][posY].GetComponent<Popino>().setDir(x, y);
			BoardManager.scacchiera[posX][posY].GetComponent<GestCarta>().esciPop();
			BoardManager.scacchiera[x][y] = BoardManager.pop;
		}
	}

	private void pt2(int x, int y)
	{
		Destroy(BoardManager.scacchiera[x][y].gameObject);
		BoardManager.scacchiera[x][y] = BoardManager.pop;
		BoardManager.scacchiera[x][y].GetComponent<Popino>().setDir(x, y);


		BoardManager.metVuot(posX, posY);
		posX = x;
		posY = y;
		if (!bloccato(x, y))
		{
			Debug.Log("BLOCCATOOOO");
			vita = 0;
			GameManager.pausa();
		}
		BoardManager.passaTurno();
		GameManager.play();
	}
}
