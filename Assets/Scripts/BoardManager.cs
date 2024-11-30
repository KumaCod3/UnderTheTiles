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
	static public bool checkLim(int x, int y)
	{
		if (x >= scacchiera.Length || y >= scacchiera[0].Length || x < 0 || y < 0 || scacchiera[x][y].GetComponent<Vuota>())    // se fuori scacchiera
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

	}

	public static bool turnoGiusto(int x)
	{
		return turno == x;
	}
}
