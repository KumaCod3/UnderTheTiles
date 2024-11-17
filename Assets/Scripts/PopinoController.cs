using System.Collections;
using UnityEngine;
public class PopinoController: MonoBehaviour
{
	public static int posX;
	public static int posY;
	public static int attacco = 1;
	public static int vita = 2;


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
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			{
				moveLeft();
			}
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				moveRight();
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				moveDown();
			}
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				moveUp();
			}
		}
	}

	private bool bloccato()
	{
		bool bl = true;

		if (BoardManager.check(posX - 1, posY))
		{
			if (!BoardManager.scacchiera[posX - 1][posY].GetComponent<CartaUscita>() || BoardManager.scacchiera[posX - 1][posY].GetComponent<CartaUscita>().costoUscita <= GameManager.punti)
			{
				if (!BoardManager.scacchiera[posX - 1][posY].GetComponent<Usata>() || GameManager.punti >= BoardManager.scacchiera[posX - 1][posY].GetComponent<Usata>().costo)
				{
					if (BoardManager.scacchiera[posX - 1][posY].GetComponent<CartaMostro2>())
					{
						BoardManager.scacchiera[posX - 1][posY].GetComponent<baseCarta>().action();
						Destroy(BoardManager.scacchiera[posX - 1][posY].gameObject);
						BoardManager.scacchiera[posX - 1][posY] = null;
					}
					bl = false;
				}
			}
		}
		if (BoardManager.check(posX + 1, posY))
		{
			if (!BoardManager.scacchiera[posX + 1][posY].GetComponent<CartaUscita>() || BoardManager.scacchiera[posX + 1][posY].GetComponent<CartaUscita>().costoUscita <= GameManager.punti)
			{
				if (!BoardManager.scacchiera[posX + 1][posY].GetComponent<Usata>() || GameManager.punti >= BoardManager.scacchiera[posX + 1][posY].GetComponent<Usata>().costo)
				{
					if (BoardManager.scacchiera[posX + 1][posY].GetComponent<CartaMostro2>())
					{
						BoardManager.scacchiera[posX + 1][posY].GetComponent<baseCarta>().action();
						Destroy(BoardManager.scacchiera[posX + 1][posY].gameObject);
						BoardManager.scacchiera[posX + 1][posY] = null;
					}
					bl = false;
				}
			}
		}
		if (BoardManager.check(posX, posY - 1))
		{
			if (!BoardManager.scacchiera[posX][posY - 1].GetComponent<CartaUscita>() || BoardManager.scacchiera[posX][posY - 1].GetComponent<CartaUscita>().costoUscita <= GameManager.punti)
			{
				if (!BoardManager.scacchiera[posX][posY - 1].GetComponent<Usata>() || GameManager.punti >= BoardManager.scacchiera[posX][posY - 1].GetComponent<Usata>().costo)
				{
					if (BoardManager.scacchiera[posX][posY - 1].GetComponent<CartaMostro2>())
					{
						BoardManager.scacchiera[posX][posY - 1].GetComponent<baseCarta>().action();
						Destroy(BoardManager.scacchiera[posX][posY - 1].gameObject);
						BoardManager.scacchiera[posX][posY - 1] = null;
					}
					bl = false;
				}
			}
		}
		if (BoardManager.check(posX, posY + 1))
		{
			if (!BoardManager.scacchiera[posX][posY + 1].GetComponent<CartaUscita>() || BoardManager.scacchiera[posX][posY + 1].GetComponent<CartaUscita>().costoUscita <= GameManager.punti)
			{
				if (!BoardManager.scacchiera[posX][posY + 1].GetComponent<Usata>() || GameManager.punti >= BoardManager.scacchiera[posX][posY + 1].GetComponent<Usata>().costo)
				{
					if (BoardManager.scacchiera[posX][posY + 1].GetComponent<CartaMostro2>() || BoardManager.scacchiera[posX][posY + 1].GetComponent<CartaMostro4>())
					{
						BoardManager.scacchiera[posX][posY + 1].GetComponent<baseCarta>().action();
						Destroy(BoardManager.scacchiera[posX][posY + 1].gameObject);
						BoardManager.scacchiera[posX][posY + 1] = null;
					}
					bl = false;
				}
			}
		}

		return bl;
	}
	internal void setXY(int x, int y)
	{
		posX = x;
		posY = y;
		GameManager.pino = this;
	}

	private void moveDown()
	{
		if (BoardManager.check(posX - 1, posY))
		{
			StartCoroutine(moveToR(posX - 1, posY));
		}
	}
	private void moveUp()
	{
		if (BoardManager.check(posX + 1, posY))
		{
			StartCoroutine(moveToR(posX + 1, posY));
		}
	}
	private void moveLeft()
	{
		if (BoardManager.check(posX, posY - 1))
		{
			StartCoroutine(moveToR(posX, posY - 1));
		}
	}
	private void moveRight()
	{
		if (BoardManager.check(posX, posY + 1))
		{
			StartCoroutine(moveToR(posX, posY + 1));
		}
	}

	public IEnumerator moveToR(int x, int y)
	{
		if (!BoardManager.scacchiera[x][y].GetComponent<CartaUscita>())
		{
			if (!BoardManager.scacchiera[x][y].GetComponent<Usata>())
			{
				BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
				GameManager.pausa();
				yield return new WaitForSeconds(.3f);

				Destroy(BoardManager.scacchiera[x][y].gameObject);
				BoardManager.metVuot(posX, posY);

				BoardManager.scacchiera[x][y] = BoardManager.pop;
				BoardManager.scacchiera[x][y].transform.position = new Vector3(y, x, 0);
				posX = x;
				posY = y;
				if (bloccato())
				{
					Debug.Log("BLOCCATOOOO");
					vita = 0;
					GameManager.pausa();
				}
				BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
				yield return new WaitForSeconds(.3f);
				BoardManager.passaTurno();
				GameManager.play();
			}
			else if (BoardManager.scacchiera[x][y].GetComponent<Usata>() && GameManager.punti >= BoardManager.scacchiera[x][y].GetComponent<Usata>().costo)
			{
				BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
				GameManager.pausa();
				yield return new WaitForSeconds(.3f);

				Destroy(BoardManager.scacchiera[x][y].gameObject);
				BoardManager.metVuot(posX, posY);

				BoardManager.scacchiera[x][y] = BoardManager.pop;
				BoardManager.scacchiera[x][y].transform.position = new Vector3(y, x, 0);
				posX = x;
				posY = y;
				if (bloccato())
				{
					Debug.Log("BLOCCATOOOO");
					vita = 0;
					GameManager.pausa();
				}

				// se vuoi anim cammina QUI

				yield return new WaitForSeconds(.3f);
				BoardManager.passaTurno();
				GameManager.play();
			}
		}
		else if (BoardManager.scacchiera[x][y].GetComponent<CartaUscita>() && BoardManager.scacchiera[x][y].GetComponent<CartaUscita>().costoUscita <= GameManager.punti)
		{
			BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
			BoardManager.scacchiera[posX][posY].transform.position = new Vector3(y, x, 0);
			BoardManager.scacchiera[posX][posY].GetComponent<GestCarta>().esciPop();
			BoardManager.scacchiera[x][y] = BoardManager.pop;
		}
	}
}
