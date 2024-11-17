using UnityEngine;
public class Popino: baseCarta
{
	Vector3 dir;
	float speed = 1.5f;

	private void Start()
	{
		tipo = "TU";
		nome = "TU";
		descrizione = "Tu.";
		dir = gameObject.transform.position;
	}
	public override void action()
	{
		base.action();
		gameObject.GetComponent<GestCarta>().wiggle();
	}
	private void Update()
	{
		gameObject.GetComponent<GestCarta>().cambia4("" + GameManager.punti);
		gameObject.GetComponent<GestCarta>().cambia1("" + PopinoController.vita);
		gameObject.GetComponent<GestCarta>().cambia2("" + PopinoController.attacco);

		transform.position = Vector3.MoveTowards(transform.position, dir, speed * Time.deltaTime);

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
	public override void ogniTurno()
	{
	}
	public void setDir(int x, int y)
	{
		dir = new Vector3(y, x, 0);
	}
}
