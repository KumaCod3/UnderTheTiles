using UnityEngine;
public class CartaBonus1: baseCarta
{
	public int attacco;

	private void Start()
	{
		gameObject.GetComponent<GestCarta>().cambia2("+" + attacco);
		gameObject.GetComponent<GestCarta>().cambia4("+1");
		descrizione = "bonus";
	}

	public override void action()
	{
		base.action();
		PopinoController.attacco += attacco;
		GameManager.punti += 1;
		Debug.Log("Bonus preso");
		Destroy(gameObject);
	}
}
