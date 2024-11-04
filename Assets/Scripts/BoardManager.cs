using UnityEngine;

public class BoardManager: MonoBehaviour
{
	public baseCarta[] riga0 = new baseCarta[7];
	public baseCarta[] riga1 = new baseCarta[7];
	public baseCarta[] riga2 = new baseCarta[7];
	public baseCarta[] riga3 = new baseCarta[7];
	public baseCarta[] riga4 = new baseCarta[7];
	public baseCarta[] riga5 = new baseCarta[7];
	public baseCarta[] riga6 = new baseCarta[7];
	private baseCarta[][] scacchiera = new baseCarta[7][];
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
				if (scacchiera[y][x])
					scacchiera[y][x].disegna(x, y);
				else
					scacchiera[y][x] = vuota;

			}

		}
	}
}
