using UnityEngine;
public class Popino: baseCarta
{

	public override void action()
	{
		base.action();

	}
	private void Update()
	{
		gameObject.GetComponent<GestCarta>().cambia4("" + GameManager.punti);
		gameObject.GetComponent<GestCarta>().cambia1("" + PopinoController.vita);
		gameObject.GetComponent<GestCarta>().cambia2("" + PopinoController.attacco);

	}
	public override void disegna(int x, int y)
	{
		GameObject card = Instantiate(gameObject, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0));
		if (gameObject.GetComponent<PopinoController>())
		{
			gameObject.GetComponent<PopinoController>().setXY(x, y);
		}
		BoardManager.assegna(card, y, x);
		BoardManager.pop = card;
	}
}
