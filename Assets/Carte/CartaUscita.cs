using UnityEngine;
public class CartaUscita: baseCarta
{

	private void Start()
	{
		base.Start();
		gameObject.GetComponent<GestCarta>().cambia4("-" + punti);
		nome = "Uscita";
	}

	private void Update()
	{
	}
	public override void action()
	{
		base.action();
		Debug.Log("WINN ");
		gameObject.GetComponent<GestCarta>().esciPorta();
		GameManager.vinto = 1;
		GameManager.pausa();

	}
	public override void ogniTurno()
	{
	}
}
