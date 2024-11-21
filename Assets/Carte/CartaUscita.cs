using UnityEngine;
public class CartaUscita: baseCarta
{

	private void Start()
	{
		base.Start();
		gameObject.GetComponent<GestCarta>().cambia4("-" + punti);
		tipo = "movimento";
		nome = "Uscita";
		descrizione = "Per vincere il livello, vieni qui.";
	}

	private void Update()
	{
	}
	public override void action()
	{
		base.action();
		Debug.Log("WINN ");
		gameObject.GetComponent<GestCarta>().esciPorta();
		GameManager.pausa();
	}
	public override void ogniTurno()
	{
	}
}
