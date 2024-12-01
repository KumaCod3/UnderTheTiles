using System;
using UnityEngine;

public class BoardManager: MonoBehaviour
{
	public static int zom;
	public GameObject[] riga0 = new GameObject[7];
	public GameObject[] riga1 = new GameObject[7];
	public GameObject[] riga2 = new GameObject[7];
	public GameObject[] riga3 = new GameObject[7];
	public GameObject[] riga4 = new GameObject[7];
	public GameObject[] riga5 = new GameObject[7];
	public GameObject[] riga6 = new GameObject[7];
	static public GameObject[][] scacchiera = new GameObject[7][];
	public GameObject vuota;
	public GameObject usa;
	public static GameObject usata;
	public static GameObject pop;

	static int turno;

	private void Start()
	{
		usata = usa;
		scacchiera[0] = riga0;
		scacchiera[1] = riga1;
		scacchiera[2] = riga2;
		scacchiera[3] = riga3;
		scacchiera[4] = riga4;
		scacchiera[5] = riga5;
		scacchiera[6] = riga6;

		turno = 0;

		for (int y = 0; y < scacchiera.Length; y++)
		{
			for (int x = 0; x < scacchiera[0].Length; x++)
			{
				if (scacchiera[x][y])
				{
					scacchiera[x][y].GetComponent<baseCarta>().disegna(y, x);
					zom = y + 1;
				}
				else
				{
					scacchiera[x][y] = vuota;
					scacchiera[x][y].GetComponent<baseCarta>().disegna(y, x);
				}
			}
		}
	}
	private void Update()
	{
	}
	static public bool check(int x, int y)
	{
		if (x >= scacchiera.Length || y >= scacchiera[0].Length || x < 0 || y < 0 || scacchiera[x][y].GetComponent<Vuota>())    // se fuori scacchiera
		{
			return false;
		}
		if (x == PopinoController.posX && y == PopinoController.posY && PopinoLivelli.alchimista)
		{
			trinca(x, y);
			PopinoLivelli.alchimista = false;
			return false;
		}
		if (x == PopinoController.posX && y == PopinoController.posY)
		{
			return false;
		}
		int xD = Mathf.Abs(PopinoController.posX - x);
		int yD = Mathf.Abs(PopinoController.posY - y);

		if (xD + yD > 1 && !PopinoLivelli.jump)  // se non adiacente
		{
			return false;

		}
		if (xD + yD > 2 && PopinoLivelli.jump)
		{
			return false;
		}
		if (xD + yD > 1 && PopinoLivelli.jump)
		{
			PopinoLivelli.jump = false;
			return true;
		}
		return true;
	}
	static void trinca(int x, int y)
	{
		Debug.Log("bevo");
		try
		{
			if (scacchiera[x + 1][y].tag.Equals("pozione"))
			{
				scacchiera[x + 1][y].GetComponent<baseCarta>().action();
				scacchiera[x + 1][y].GetComponent<GestCarta>().wiggle();
				metVuot(x + 1, y);
			}
		}
		catch (Exception e) { }
		try
		{
			if (scacchiera[x - 1][y].tag.Equals("pozione"))
			{
				scacchiera[x - 1][y].GetComponent<baseCarta>().action();
				scacchiera[x - 1][y].GetComponent<GestCarta>().wiggle();
				metVuot(x - 1, y);
			}
		}
		catch (Exception e) { }
		try
		{
			if (scacchiera[x][y + 1].tag.Equals("pozione"))
			{
				scacchiera[x][y + 1].GetComponent<baseCarta>().action();
				scacchiera[x][y + 1].GetComponent<GestCarta>().wiggle();
				metVuot(x, y + 1);
			}
		}
		catch (Exception e) { }
		try
		{
			if (scacchiera[x][y - 1].tag.Equals("pozione"))
			{
				scacchiera[x][y - 1].GetComponent<baseCarta>().action();
				scacchiera[x][y - 1].GetComponent<GestCarta>().wiggle();
				metVuot(x, y - 1);
			}
		}
		catch (Exception e) { }
	}
	static public bool checkLim(int x, int y)
	{
		if (x >= scacchiera.Length || y >= scacchiera[0].Length || x < 0 || y < 0 || scacchiera[x][y] == null || scacchiera[x][y].GetComponent<Vuota>())    // se fuori scacchiera
		{
			return false;
		}
		return true;
	}

	public static void assegna(GameObject card, int x, int y)
	{
		scacchiera[x][y] = card;
	}
	public static void riempi()
	{
		for (int y = 0; y < scacchiera.Length; y++)
		{
			for (int x = 0; x < scacchiera[0].Length; x++)
			{
				if (!scacchiera[x][y])
				{

					scacchiera[x][y] = usata;
					scacchiera[x][y].GetComponent<baseCarta>().disegna(y, x);
				}
			}
		}
	}

	public static GameObject sopraCarta(int x, int y)
	{
		return scacchiera[x][y];
	}

	public static void metVuot(int x, int y)
	{
		scacchiera[x][y] = usata;
		scacchiera[x][y].GetComponent<baseCarta>().disegna(y, x);
	}
	public static void passaTurno()
	{
		for (int y = 0; y < scacchiera.Length; y++)
		{
			for (int x = 0; x < scacchiera[0].Length; x++)
			{
				if (scacchiera[x][y] && scacchiera[x][y].GetComponent<baseCarta>())
				{
					scacchiera[x][y].GetComponent<baseCarta>().ogniTurno();
				}
			}
		}
		turno++;
	}
	public static void scambia(int[] cor, int[] cornew)
	{
		GameObject old = scacchiera[cor[1]][cor[0]];
		GameObject neww = scacchiera[cornew[1]][cornew[0]];

		scacchiera[cor[1]][cor[0]] = neww;
		scacchiera[cornew[1]][cornew[0]] = old;

		neww.GetComponent<baseCarta>().StartCoroutine(neww.GetComponent<baseCarta>().scivola(new Vector3(cor[0], cor[1], -1), 2));
		//	neww.transform.position = new Vector3(cor[0], cor[1], -1);

		//neww.transform.position = Vector3.MoveTowards(neww.transform.position, new Vector3(cor[0], cor[1], -1), 50f * Time.deltaTime);
	}

	public static bool turnoGiusto(int x)
	{
		return turno == x;
	}

	public static void fulminaDa(int x, int y)
	{
		int[] cor = fulmine(x, y);
		if (cor != null)
		{
			fulminaDa(cor[0], cor[1]);
		}
	}

	public static int[] fulmine(int x, int y)
	{
		try
		{
			if (scacchiera[x + 1][y].tag.Equals("mostro") && !scacchiera[x + 1][y].GetComponent<baseCarta>().fulminato)
			{
				scacchiera[x + 1][y].GetComponent<baseCarta>().togli1();
				scacchiera[x + 1][y].GetComponent<baseCarta>().fulminato = true;
				scacchiera[x + 1][y].GetComponent<GestCarta>().wiggle();
				int[] cc = { x + 1, y };
				return cc;
			}
		}
		catch (Exception e) { }
		try
		{
			if (scacchiera[x][y - 1].tag.Equals("mostro") && !scacchiera[x + 1][y].GetComponent<baseCarta>().fulminato)
			{
				scacchiera[x][y - 1].GetComponent<baseCarta>().togli1();
				scacchiera[x + 1][y].GetComponent<baseCarta>().fulminato = true;
				scacchiera[x + 1][y].GetComponent<GestCarta>().wiggle();
				int[] cc = { x, y - 1 };
				return cc;
			}
		}
		catch (Exception e) { }
		try
		{
			if (scacchiera[x - 1][y].tag.Equals("mostro") && !scacchiera[x + 1][y].GetComponent<baseCarta>().fulminato)
			{
				scacchiera[x - 1][y].GetComponent<baseCarta>().togli1();
				scacchiera[x + 1][y].GetComponent<baseCarta>().fulminato = true;
				scacchiera[x + 1][y].GetComponent<GestCarta>().wiggle();
				int[] cc = { x - 1, y };
				return cc;
			}
		}
		catch (Exception e) { }
		try
		{
			if (scacchiera[x][y + 1].tag.Equals("mostro") && !scacchiera[x + 1][y].GetComponent<baseCarta>().fulminato)
			{
				scacchiera[x][y + 1].GetComponent<baseCarta>().togli1();
				scacchiera[x + 1][y].GetComponent<baseCarta>().fulminato = true;
				scacchiera[x + 1][y].GetComponent<GestCarta>().wiggle();
				int[] cc = { x, y + 1 };
				return cc;
			}
		}
		catch (Exception e) { }

		return null;
	}
}
