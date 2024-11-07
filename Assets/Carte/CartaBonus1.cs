using UnityEngine;

public class CartaBonus1: baseCarta
{
	public int punti;
	public override void action()
	{
		GameManager.punti = GameManager.punti + punti;
		Debug.Log("Bonus preso");
		Destroy(gameObject);
	}
}
