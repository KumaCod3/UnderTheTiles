using UnityEngine;

public class GameManager: MonoBehaviour
{
	bool inMovimento = false;
	public int posX;
	public int posY;
	void Start()
	{
	}

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
	private void moveLeft()
	{
	}
	private void moveRight()
	{
	}
	private void moveDown()
	{
	}
	private void moveUp()
	{
	}
}
