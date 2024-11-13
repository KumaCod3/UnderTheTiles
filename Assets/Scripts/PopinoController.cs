using UnityEngine;

public class PopinoController: MonoBehaviour
{
	public static int posX;
	public static int posY;
	public static int attacco = 1;
	public static int vita = 2;


	void Update()
	{
		/*
		if (Input.anyKeyDown)
		{
			if (bloccato())
			{
				vita = 0;
			}
		}*/
		if (!GameManager.pausa)
		{

			if (vita <= 0)
			{
				Debug.Log("GAME OVEEEEER!!!!");
				Destroy(gameObject);
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
			if (BoardManager.scacchiera[posX - 1][posY].GetComponent<CartaUscita>() || BoardManager.scacchiera[posX - 1][posY].GetComponent<Usata>())
			{

			}
		}
		if (BoardManager.check(posX + 1, posY))
		{
		}
		if (BoardManager.check(posX, posY - 1))
		{
		}
		if (BoardManager.check(posX, posY + 1))
		{
		}

		return bl;
	}
	internal void setXY(int x, int y)
	{
		posX = x;
		posY = y;
		GameManager.pino = this;
		//gameObject.GetComponent<PopinoController>();
	}

	private void moveDown()
	{
		Debug.Log("da " + posX + "," + posY + " a " + (posX - 1) + "," + posY + BoardManager.check(posX - 1, posY));
		if (BoardManager.check(posX - 1, posY))
		{
			moveTo(posX - 1, posY);
		}
	}
	private void moveUp()
	{
		Debug.Log("da " + posX + "," + posY + " a " + (posX + 1) + "," + posY + BoardManager.check(posX + 1, posY));
		if (BoardManager.check(posX + 1, posY))
		{
			moveTo(posX + 1, posY);
		}
	}
	private void moveLeft()
	{
		Debug.Log("da " + posX + "," + posY + " a " + (posX) + "," + (posY - 1) + BoardManager.check(posX, posY - 1));
		if (BoardManager.check(posX, posY - 1))
		{
			moveTo(posX, posY - 1);
		}
	}
	private void moveRight()
	{
		Debug.Log("da " + posX + "," + posY + " a " + (posX) + "," + (posY + 1) + BoardManager.check(posX, posY + 1));
		if (BoardManager.check(posX, posY + 1))
		{
			moveTo(posX, posY + 1);
		}
	}
	public void moveTo(int x, int y)
	{
		if (!BoardManager.scacchiera[x][y].GetComponent<CartaUscita>() || BoardManager.scacchiera[x][y].GetComponent<CartaUscita>().costoUscita <= GameManager.punti)
		{
			if (!BoardManager.scacchiera[x][y].GetComponent<Usata>() || GameManager.punti >= BoardManager.scacchiera[x][y].GetComponent<Usata>().costo)
			{

				BoardManager.scacchiera[x][y].GetComponent<baseCarta>().action();
				Destroy(BoardManager.scacchiera[x][y].gameObject);
				BoardManager.scacchiera[posX][posY] = null;
				BoardManager.scacchiera[x][y] = BoardManager.pop;
				//	Debug.Log("muovo da " + transform.position);
				BoardManager.scacchiera[x][y].transform.position = new Vector3(y, x, 0);
				//Debug.Log(gameObject.name + " a " + transform.position);
				posX = x;
				posY = y;
			}
		}
	}
}
