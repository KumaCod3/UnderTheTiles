using UnityEngine;
public class Vuota: baseCarta
{
	private void Start()
	{
		descrizione = "...";
	}
	public override void action()
	{
		base.action();
	}
	public override void disegna(int x, int y)
	{
		GameObject card = Instantiate(gameObject, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0), GameObject.Find("/Vuote").transform);
		if (gameObject.GetComponent<PopinoController>())
		{
			gameObject.GetComponent<PopinoController>().setXY(x, y);
		}
		BoardManager.assegna(card, y, x);
	}
}
