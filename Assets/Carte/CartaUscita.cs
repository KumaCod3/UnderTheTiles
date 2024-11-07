using UnityEngine;

public class CartaUscita: baseCarta
{
	public int costoUscita;
	public override void action()
	{
		if (GameManager.punti >= costoUscita)
		{
			Debug.Log("Winner");
		}
		else
		{
			int tp = costoUscita - GameManager.punti;
			Debug.Log("manccano " + tp + " punti");
		}
	}
}
