using UnityEngine;

public class BoardManager: MonoBehaviour
{
	public static int zom;
	public baseCarta[] riga0 = new baseCarta[7];
	public baseCarta[] riga1 = new baseCarta[7];
	public baseCarta[] riga2 = new baseCarta[7];
	public baseCarta[] riga3 = new baseCarta[7];
	public baseCarta[] riga4 = new baseCarta[7];
	public baseCarta[] riga5 = new baseCarta[7];
	public baseCarta[] riga6 = new baseCarta[7];
	static public baseCarta[][] scacchiera = new baseCarta[7][];
	public baseCarta vuota;


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
					scacchiera[x][y].disegna(y, x);
					zom = y + 1;
				}
				else
				{
					scacchiera[x][y] = vuota;
					scacchiera[x][y].disegna(y, x);
				}
			}

		}
	}
	static public bool check(int x, int y)
	{
		if (x >= scacchiera.Length || y >= scacchiera[0].Length || x < 0 || y < 0)
		{
			Debug.Log("OUT");
			return false;
		}
		return !scacchiera[x][y].GetComponent<Vuota>();
	}

}
