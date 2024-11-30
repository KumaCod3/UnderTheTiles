using System.Collections;
using UnityEngine;
public class PopinoController: MonoBehaviour
{
	public static int posX;
	public static int posY;
	public static int vitta;
	static bool ebloccato;

	public void camVita(int v)
	{
		if (PopinoLivelli.shield && v < vitta && !ebloccato)
		{
			PopinoLivelli.shield = false;
			return;
		}
		//		gameObject.GetComponent<Popino>().vita = v;
		vitta = v;
		gameObject.GetComponent<GestCarta>().cambia1("" + vitta, true);
	}
	public void camAtta(int a)
	{
		gameObject.GetComponent<Popino>().attacco = a;
		gameObject.GetComponent<GestCarta>().cambia2("" + gameObject.GetComponent<Popino>().attacco, true);
	}
	public void camPun(int p)
	{
		GameManager.punti = p;
		gameObject.GetComponent<GestCarta>().cambia4("" + GameManager.punti, true);
	}
	public int getVita()
	{
		return vitta;
		//		gameObject.GetComponent<Popino>().vita;
	}
	public int getAttacco()
	{
		return gameObject.GetComponent<Popino>().attacco;
	}

	void Update()
	{

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
					if (BoardManager.scacchiera[x][y].GetComponent<CartaMostro2>() /*|| BoardManager.scacchiera[x][y].GetComponent<CartaMostro3>()*/)
					{
						BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
						Destroy(BoardManager.scacchiera[x][y].gameObject);
						//	BoardManager.scacchiera[x][y] = null;
						BoardManager.metVuot(x, y);
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
		bool uno = prova(x - 1, y);
		bool due = prova(x + 1, y);
		bool tre = prova(x, y - 1);
		bool quat = prova(x, y + 1);


		return uno || due || tre || quat;
		//		return (prova(x - 1, y) || prova(x + 1, y) || prova(x, y - 1) || prova(x, y + 1));
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


				//				pt2(x, y);
				Destroy(BoardManager.scacchiera[x][y].gameObject);
				BoardManager.scacchiera[x][y] = BoardManager.pop;
				BoardManager.scacchiera[x][y].GetComponent<Popino>().setDir(x, y);
				BoardManager.metVuot(posX, posY);
				posX = x;
				posY = y;
				if (!bloccato(x, y))
				{
					GameManager.play();
					vitta = 0;
					ebloccato = true;
					yield break;
				}
				yield return new WaitForSeconds(.1f);
				BoardManager.passaTurno();
				yield return new WaitForSeconds(.1f);
				GameManager.play();

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
			gameObject.GetComponent<Popino>().vita = 0;
		}
	}
}
