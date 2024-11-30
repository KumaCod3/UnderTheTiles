using UnityEngine;

public class CartaMostro3: baseCarta
{

	public int possX;
	public int possY;

	public Vector3 dir;
	float speed = 1.5f;
	int turno;
	public override void Start()
	{
		base.Start();
		nome = "Mostro 3";
		dir = transform.position;
		possX = (int)dir.x;
		possY = (int)dir.y;
		turno = 0;
	}
	public void setDir(int x, int y)
	{
		dir = new Vector3(x, y, -1);
	}
	public override void action()
	{
		base.action();
		combat();
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, dir, speed * Time.deltaTime);
	}
	public override void ogniTurno()
	{
		if (BoardManager.turnoGiusto(turno))
		{
			if ((distanzaX() + distanzaY()) > 1)
			{
				if ((distanzaY() > distanzaX()))
				{
					//					Debug.Log("muovo x");
					muoviX();
				}
				else
				{
					//					Debug.Log("muovo y");
					muoviY();
				}
			}

			if ((distanzaX() + distanzaY()) <= 1)
			{
				//action();
				Debug.Log("Attaccoooo");
			}
			turno++;
		}
	}

	public void setXY(int x, int y)
	{
		possX = y;
		possY = x;
		transform.position = dir;
	}

	int distanzaX()
	{
		int xxx = Mathf.Abs(PopinoController.posX - possY);
		return xxx;
	}
	int distanzaY()
	{
		int yyy = Mathf.Abs(PopinoController.posY - possX);
		return yyy;
	}
	void muoviX()
	{
		int x = passo(possX, PopinoController.posY);
		dir = new Vector3(x, dir.y, dir.z);
		possX = (int)dir.x;
		possY = (int)dir.y;

		int[] cor = { possX, possY };
		possX = (int)dir.x;
		possY = (int)dir.y;
		int[] corNe = { possX, possY };
		BoardManager.scambia(cor, corNe);
	}

	void muoviY()
	{
		int y = passo(possY, PopinoController.posX);
		dir = new Vector3(dir.x, y, dir.z);
		int[] cor = { possX, possY };
		possX = (int)dir.x;
		possY = (int)dir.y;
		int[] corNe = { possX, possY };
		BoardManager.scambia(cor, corNe);
	}
	private int passo(int a, int b)
	{
		if (a > b)
		{
			return a - 1;
		}
		else if (a < b)
		{
			return a + 1;
		}
		else
		{
			return a;
		}
	}
}
