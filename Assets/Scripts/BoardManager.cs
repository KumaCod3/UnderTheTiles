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
	public GameObject usata;
	public static GameObject pop;

	private void Start()
	{
		scacchiera[0] = riga0;
		scacchiera[1] = riga1;
		scacchiera[2] = riga2;
		scacchiera[3] = riga3;
		scacchiera[4] = riga4;
		scacchiera[5] = riga5;
		scacchiera[6] = riga6;

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
		riempi();
	}
	static public bool check(int x, int y)
	{
		if (x >= scacchiera.Length || y >= scacchiera[0].Length || x < 0 || y < 0 || scacchiera[x][y].GetComponent<Vuota>())    // se fuori scacchiera
		{
			return false;
		}
		int xD = Mathf.Abs(PopinoController.posX - x);
		int yD = Mathf.Abs(PopinoController.posY - y);
		if (xD + yD != 1)   // se non adiacente
		{
			return false;
		}
		return true;
	}

	public static void assegna(GameObject card, int x, int y)
	{
		scacchiera[x][y] = card;
	}
	public void riempi()
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
}
