using UnityEngine;

public class PopinoController: MonoBehaviour
{
	bool inMovimento = false;
	public int posX;
	public int posY;
	public static int attacco = 2;
	public static int vita = 2;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			moveLeft();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			moveRight();
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			moveDown();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			moveUp();
		}
	}

	internal void setXY(int x, int y)
	{
		posX = x;
		posY = y;
	}

	private void moveLeft()
	{
		Debug.Log("da " + posX + "," + posY + " a " + (posX - 1) + "," + posY + BoardManager.check(posX - 1, posY));
		if (BoardManager.check(posX - 1, posY))
		{
			moveTo(posX - 1, posY);
		}
	}
	private void moveRight()
	{
		Debug.Log("da " + posX + "," + posY + " a " + (posX + 1) + "," + posY + BoardManager.check(posX + 1, posY));
		if (BoardManager.check(posX + 1, posY))
		{
			moveTo(posX + 1, posY);
		}
	}
	private void moveDown()
	{
		Debug.Log("da " + posX + "," + posY + " a " + (posX) + "," + (posY - 1) + BoardManager.check(posX, posY - 1));
		if (BoardManager.check(posX, posY - 1))
		{
			moveTo(posX, posY - 1);
		}
	}
	private void moveUp()
	{
		Debug.Log("da " + posX + "," + posY + " a " + (posX) + "," + (posY + 1) + BoardManager.check(posX, posY + 1));
		if (BoardManager.check(posX, posY + 1))
		{
			moveTo(posX, posY + 1);
		}
	}
	static public void moveTo(int x, int y)
	{

	}
}
