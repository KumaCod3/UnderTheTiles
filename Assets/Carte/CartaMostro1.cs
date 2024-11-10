using UnityEngine;
public class CartaMostro1: baseCarta
{
	public int punti;
	public int vita;
	public int attacco;

	private void Start()
	{
		descrizione = "mostro";
	}
	private void Update()
	{
		gameObject.GetComponent<GestCarta>().cambia1("" + vita);
		gameObject.GetComponent<GestCarta>().cambia2("" + attacco);
		gameObject.GetComponent<GestCarta>().cambia4("+" + punti);
	}
	public override void action()
	{
		base.action();

		while (vita > 0 && PopinoController.vita > 0)
		{
			vita = vita - PopinoController.attacco;
			PopinoController.vita = PopinoController.vita - attacco;
		}
		if (vita <= 0)
		{
			GameManager.punti = GameManager.punti + punti;
			Debug.Log("mostro battuto");
			Destroy(gameObject);
		}
	}
}
