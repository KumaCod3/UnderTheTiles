using UnityEngine;
public class Popino: baseCarta
{

	private void Start()
	{
		tipo = "TU";
		nome = "TU";
		descrizione = "Tu.";
	}
	public override void action()
	{
		base.action();
		Debug.Log("wiggle?");
		gameObject.GetComponent<GestCarta>().wiggle();
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
