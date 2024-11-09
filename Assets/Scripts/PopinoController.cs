using UnityEngine;

public class PopinoController: MonoBehaviour
{
	bool inMovimento = false;
	public static int posX;
	public static int posY;
	public static int attacco = 2;
	public static int vita = 2;


	void Update()
	{
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
